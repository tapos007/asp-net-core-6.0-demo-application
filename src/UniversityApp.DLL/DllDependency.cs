using Microsoft.Extensions.DependencyInjection;
using UniversityApp.DLL.Repository;
using UniversityApp.DLL.UOW;

namespace UniversityApp.DLL
{
    public static class DllDependency
    {
        public static IServiceCollection AddDllDependency(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IDepartmentRepository, DepartmentRepository>();
            return service;
        }
    }
}