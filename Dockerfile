# ─── Stage 1: Build ───────────────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Install the Blazor/WASM workload so _framework static assets (blazor.web.js etc.) are bundled
RUN dotnet workload install wasm-tools --skip-sign-check

# Copy project file and restore dependencies first (layer cache optimisation)
COPY BeeKeeping/BeeKeeping.csproj BeeKeeping/
RUN dotnet restore BeeKeeping/BeeKeeping.csproj

# Copy the rest of the source and publish
COPY BeeKeeping/ BeeKeeping/
WORKDIR /src/BeeKeeping
RUN dotnet publish BeeKeeping.csproj -c Release -o /app/publish

# ─── Stage 2: Runtime ─────────────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Create the data directory that will be bind-mounted for SQLite persistence
RUN mkdir -p /data && chmod 777 /data

COPY --from=build /app/publish .

# DATA_PATH tells Program.cs where to store beekeeping.db
ENV DATA_PATH=/data
# Listen on HTTP only; TLS is handled by the NAS reverse proxy
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 18085

ENTRYPOINT ["dotnet", "BeeKeeping.dll"]
