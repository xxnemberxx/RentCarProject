using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v => v.VehicleId);
            builder.Property(v => v.LicensePlate).HasMaxLength(25).IsRequired();
            builder.Property(v => v.Location).HasMaxLength(500).IsRequired();
            builder.Property(v => v.PricePerHr).IsRequired();
            builder.Property(v => v.ModelId).IsRequired();
            builder.Property(v => v.ColorId).IsRequired();
        }
    }
}
