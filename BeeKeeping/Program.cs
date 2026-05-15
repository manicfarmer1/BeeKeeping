using BeeKeeping.Components;
using BeeKeeping.Data;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Accept forwarded headers from any source (LAN reverse proxy / Docker bridge network).
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

// When running in Docker, DATA_PATH env var points to the mounted persistent volume.
// Falls back to ContentRootPath for local development.
var dataDir = Environment.GetEnvironmentVariable("DATA_PATH")
    ?? builder.Environment.ContentRootPath;
Directory.CreateDirectory(dataDir);
var dbPath = Path.Combine(dataDir, "beekeeping.db");
builder.Services.AddDbContextFactory<BeeKeepingDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddScoped<AppConfigurationService>();

// Persist Data Protection keys to the volume so antiforgery tokens survive container restarts.
var keysDir = new DirectoryInfo(Path.Combine(dataDir, "dataprotection-keys"));
keysDir.Create();
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(keysDir)
    .SetApplicationName("BeeKeeping");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // HSTS is intentionally omitted — this container serves HTTP only.
    // TLS termination is handled by the NAS reverse proxy.
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseForwardedHeaders();

app.UseAntiforgery();

// Ensure database is created and migrations applied
using (var scope = app.Services.CreateScope())
{
    var dbFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<BeeKeepingDbContext>>();
    using var db = dbFactory.CreateDbContext();
    db.Database.Migrate();
}

app.UseStaticFiles();  // serves wwwroot + _framework files (including blazor.web.js)
app.MapStaticAssets(); // fingerprinted asset support (used in development/local)
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
