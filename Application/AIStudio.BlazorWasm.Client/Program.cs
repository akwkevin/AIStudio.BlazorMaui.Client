using AIStudio.Blazor.Common;
using AIStudio.Blazor.Common.Data;
using AIStudio.Blazor.Common.ServiceExtensions;
using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Main>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));
builder.Services.AddServiceSetup();    // 第2外：添加扩展方法引入服务

await builder.Build().RunAsync();
