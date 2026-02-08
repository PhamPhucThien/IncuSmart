using IncuSmart.Infra.Persistences.Entities;
using Microsoft.EntityFrameworkCore;

namespace IncuSmart.Infra.Persistences
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; } = null!;

        public DbSet<CustomerEntity> Customers { get; set; } = null!;

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<Enum>()
                .HaveConversion<string>();
        }
    }
}
