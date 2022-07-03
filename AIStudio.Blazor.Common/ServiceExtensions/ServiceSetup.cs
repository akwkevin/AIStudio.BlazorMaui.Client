using AIStudio.Blazor.Common.Services;
using AntDesign.ProLayout;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Blazor.Common.ServiceExtensions
{
    public static class ServiceSetup
    {
        public static void AddServiceSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAntDesign();   // 这句关键代码

            services.AddScoped<IChartService, ChartService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProfileService, ProfileService>();
        }
    }
}
