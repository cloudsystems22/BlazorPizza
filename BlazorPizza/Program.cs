using BlazorPizza;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RclOrdering.Services.Interfaces;
using RclOrdering.Services;
using RclProducts.Services.Interfaces;
using RclProducts.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IOrderingRestServices, OrderingRestServices>();
builder.Services.AddScoped<IProductsRestServices, ProductsRestServices>();
builder.Services.AddScoped<ISizeRestServices, SizeRestServices>();
builder.Services.AddScoped<IUtilsSizeServices, UtilsSizeServices>();
builder.Services.AddScoped<ISliderUtilsServices, SliderUtilsServices>();
builder.Services.AddScoped<ICardsUtilsServices, CardsUtilsServices>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7255") });

await builder.Build().RunAsync();
