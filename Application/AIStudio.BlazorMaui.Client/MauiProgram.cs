using AIStudio.Blazor.Common.Data;
using AIStudio.Blazor.Common.ServiceExtensions;
using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace AIStudio.BlazorMaui.Client
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

            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(sp.GetService<NavigationManager>().BaseUri)
            });
            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));
            builder.Services.AddServiceSetup();    // 第2外：添加扩展方法引入服务

            return builder.Build();
        }
    }
}