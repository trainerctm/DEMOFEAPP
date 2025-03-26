using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DemoFEApp;
using DemoFEApp.Services;
using DemoFEApp.AuthServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Base URL points to your ASP.NET Core API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("ApiBaseUrl") });

builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<ProductService>();

await builder.Build().RunAsync();
