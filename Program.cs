using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DemoFEApp;
using DemoFEApp.Services;
using DemoFEApp.AuthServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Inject IConfiguration for dynamic app settings
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Dynamically load the base URL for the HttpClient
var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? throw new InvalidOperationException("ApiBaseUrl is not configured.");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

// Add scoped services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ProductService>();

await builder.Build().RunAsync();
