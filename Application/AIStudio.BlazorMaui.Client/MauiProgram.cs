﻿using AIStudio.Blazor.Common.Data;
using AIStudio.Blazor.Common.ServiceExtensions;

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

            builder.Services.AddServiceSetup();    // 第2外：添加扩展方法引入Masa Blazor

            return builder.Build();
        }
    }
}