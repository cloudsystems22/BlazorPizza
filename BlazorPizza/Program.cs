using BlazorPizza;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RclOrdering.Services;
using RclOrdering.Services.Interfaces;
using RclProducts.Services;
using RclProducts.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IOrderingRestServices, OrderingRestServices>();
builder.Services.AddScoped<IProductsRestServices, ProductsRestServices>();
builder.Services.AddScoped<ISizeRestServices, SizeRestServices>();
builder.Services.AddScoped<IUtilsSizeServices, UtilsSizeServices>();
builder.Services.AddScoped<ISliderUtilsServices, SliderUtilsServices>();

await builder.Build().RunAsync();
