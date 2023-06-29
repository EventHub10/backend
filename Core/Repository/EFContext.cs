using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Core.Repository
{
    public class EFContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public EFContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Sample> Samples { get; set; }

    }
}
