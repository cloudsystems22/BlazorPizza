using Microsoft.Extensions.Logging;
using RclOrdering.Services.Interfaces;
using RclOrdering.Services;
using RclProducts.Services.Interfaces;
using RclProducts.Services;

namespace MauiBlazorPizza
{
    public static class MauiProgram
    {
        public static string BaseAddress = 
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5096" : "https://localhost:7255";
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
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddScoped<IOrderingRestServices, OrderingRestServices>();
            builder.Services.AddScoped<IProductsRestServices, ProductsRestServices>();
            builder.Services.AddScoped<ISizeRestServices, SizeRestServices>();
            builder.Services.AddScoped<IUtilsSizeServices, UtilsSizeServices>();
            builder.Services.AddScoped<ISliderUtilsServices, SliderUtilsServices>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(BaseAddress) });

            return builder.Build();
        }
    }
}
