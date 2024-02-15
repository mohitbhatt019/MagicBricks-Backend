using MagicBricks.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MagicBricks.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected readonly IConfiguration _configuration;
        public ApplicationDbContext(IConfiguration configuration, DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Property> properties { get; set; }
        public DbSet<PropertyDetail> propertyDetails { get; set; }
        public DbSet<BookMark> bookMarks { get; set; }


    }
}
