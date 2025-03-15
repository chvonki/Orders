using CargoOrders.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CargoOrders.Data.Configurations;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasOne(o => o.SenderLocation)
            .WithMany()
            .HasForeignKey(o => o.SenderLocationId)
            .IsRequired();
        
        builder.HasOne(o => o.ReceiverLocation)
            .WithMany()
            .HasForeignKey(o => o.ReceiverLocationId)
            .IsRequired();
        
        builder.HasOne(o => o.Cargo)
            .WithMany()
            .HasForeignKey(o => o.CargoId)
            .IsRequired();

        builder.Property(o => o.PickupAt)
            .IsRequired();
    }
}