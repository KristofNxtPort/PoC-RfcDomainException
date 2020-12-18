using Microsoft.EntityFrameworkCore;
using PoC_RfcDomainException.Database.Contract.Models;

namespace PoC_RfcDomainException.Database
{
    internal class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarDbContext).Assembly);
        }
    }
}