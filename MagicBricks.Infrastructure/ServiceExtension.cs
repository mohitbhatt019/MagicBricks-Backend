using MagicBricks.Applications.Interfaces.IRepository;
using MagicBricks.Domain.Entities;
using MagicBricks.Infrastructure.Context;
using MagicBricks.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MagicBricks.Infrastructure
{
    public static class ServiceExtension
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>();

            // Register UserManager<ApplicationUser> and SignInManager<ApplicationUser>
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IAuthenticationRepository, UserAuthenticationRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
        }
    }
}
