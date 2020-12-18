using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoC_RfcDomainException.Database.Contract.Models;

namespace PoC_RfcDomainException.Database.Configurations
{
    internal class CarEntityConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Car");

            builder.HasKey(key => new { key.Brand, key.Model });
        }
    }
}