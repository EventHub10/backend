using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Core.Repository
{
    public class EFContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public EFContext(IConfiguration configuration) : base()
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies();
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));

        }

        public DbSet<Event> Events { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Confirmed_People> Confirmed_Peoples { get; set; }

    }
}
