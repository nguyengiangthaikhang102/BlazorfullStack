global using BlazorfullStack.Client.Services.SuperHeroServices;
global using BlazorfullStack.Client.Services.SinhVienServices;
global using BlazorfullStack.Shared;
using BlazorfullStack.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
builder.Services.AddScoped<ISinhVienService, SinhVienService>();
await builder.Build().RunAsync();
