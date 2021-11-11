using Microsoft.Extensions.DependencyInjection;
using UniversityApp.BLL.Services;

namespace UniversityApp.BLL
{
    public static class BllDependency
    {
        public static IServiceCollection AllBllDependency(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            return services;
        }
    }
}