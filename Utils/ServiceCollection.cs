using SMS_backend.Controllers;

namespace SMS_backend.Utils
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<UserService>();
            return service;
        }
        public static IServiceCollection AddQueries(this IServiceCollection service)
        {
            service.AddScoped<UserQueries>();
            return service;
        }
    }
}
