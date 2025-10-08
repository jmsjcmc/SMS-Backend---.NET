using SMS_backend.Controllers;

namespace SMS_backend.Utils
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<UserService>();
            service.AddScoped<RoleService>();
            service.AddScoped<DepartmentService>();
            service.AddScoped<PositionService>();
            service.AddScoped<ProductService>();
            return service;
        }
        public static IServiceCollection AddQueries(this IServiceCollection service)
        {
            service.AddScoped<UserQueries>();
            service.AddScoped<RoleQueries>();
            service.AddScoped<DepartmentQueries>();
            service.AddScoped<PositionQueries>();
            return service;
        }
    }
}
