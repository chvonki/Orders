using CargoOrders.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CargoOrders.Data.Configurations;

internal sealed class CargoConfiguration : IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Weight)
            .HasPrecision(18, 2)
            .IsRequired();
    }
}