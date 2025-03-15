using CargoOrders.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CargoOrders.Data.Configurations;

internal sealed class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Address)
            .HasMaxLength(256)
            .IsRequired();
        
        builder.Property(l => l.City)
            .HasMaxLength(256)
            .IsRequired();
    }
}