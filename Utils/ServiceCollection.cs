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
            service.AddScoped<CategoryService>();
            return service;
        }
        public static IServiceCollection AddQueries(this IServiceCollection service)
        {
            service.AddScoped<UserQueries>();
            service.AddScoped<RoleQueries>();
            service.AddScoped<DepartmentQueries>();
            service.AddScoped<PositionQueries>();
            service.AddScoped<ProductQueries>();
            service.AddScoped<CategoryQueries>();
            return service;
        }
        public static IServiceCollection AddCORS(this IServiceCollection service)
        {
            service.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowSpecificOrigin",
                    builder =>
                    {
                        builder
                            .WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });
            return service;
        }
    }
}
