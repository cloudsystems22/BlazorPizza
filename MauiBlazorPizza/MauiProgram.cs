using Microsoft.AspNetCore.Components.WebView.Maui;
using RclOrdering.Services;
using RclOrdering.Services.Interfaces;
using RclProducts.Services.Interfaces;
using RclProducts.Services;

namespace MauiBlazorPizza
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            builder.Services.AddScoped<IOrderingRestServices, OrderingRestServices>();
            builder.Services.AddScoped<IProductsRestServices, ProductsRestServices>();
            builder.Services.AddScoped<ISizeRestServices, SizeRestServices>();
            return builder.Build();
        }
    }
}