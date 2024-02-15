using MagicBricks.Applications.DTOs.DTOMapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MagicBricks.Applications
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // Set DTOs configuration
            services.AddAutoMapper(typeof(MappingProfile));


            //Set MediatR configuration
            services.AddMediatR(_ => _.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


        }
    }
}
