using CargoOrders.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CargoOrders.Data;

/// <summary>
/// Контекст базы данных
/// </summary>
public sealed class CargoOrderContext : DbContext
{
    /// <summary>
    /// Грузы
    /// </summary>
    public DbSet<Cargo> Cargoes => Set<Cargo>();
    
    /// <summary>
    /// Местоположения
    /// </summary>
    public DbSet<Location> Locations => Set<Location>();
    
    /// <summary>
    /// Заказы
    /// </summary>
    public DbSet<Order> Orders => Set<Order>();
    
    public CargoOrderContext(DbContextOptions<CargoOrderContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CargoOrderContext).Assembly);
    }
}