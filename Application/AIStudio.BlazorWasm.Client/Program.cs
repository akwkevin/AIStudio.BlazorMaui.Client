using AIStudio.Blazor.Common;
using AIStudio.Blazor.Common.Data;
using AIStudio.Blazor.Common.ServiceExtensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Main>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddServiceSetup();    // 第2外：添加扩展方法引入Masa Blazor

await builder.Build().RunAsync();
