using MagicBricks.Applications.Interfaces.IRepository;
using MagicBricks.Infrastructure.Repositories;

namespace MagicBricks_Clone
{
    public static class ServiceExtensions
    {

        public static void AddCustomServices(this IServiceCollection services)
        {
            // Register your custom services here
            services.AddScoped<IAuthenticationRepository, UserAuthenticationRepository>();
            // Add other services as needed
        }

    }
}
