using AIStudio.Blazor.Common.Data;
using AIStudio.Blazor.Common.ServiceExtensions;
using AIStudio.Blazor.Common.Services;
using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components;

namespace AIStudio.BlazorServer.Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
  
            services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(sp.GetService<NavigationManager>().BaseUri)
            });
            services.Configure<ProSettings>(Configuration.GetSection("ProSettings"));

            services.AddServiceSetup();    // 第2外：添加扩展方法引入服务
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
