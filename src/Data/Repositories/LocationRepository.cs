using CargoOrders.Business.Repositories;
using CargoOrders.Data.Exceptions;
using CargoOrders.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CargoOrders.Data.Repositories;

internal sealed class LocationRepository : ILocationRepository
{
    private readonly CargoOrderContext context;

    public LocationRepository(CargoOrderContext context)
    {
        this.context = context;
    }
    
    public async Task<IReadOnlyList<Location>> GetAllAsync(int offset = 0, int limit = 10, CancellationToken cancellationToken = default)
    {
        return await context.Locations
            .Include(l => l.Orders)
            .Skip(offset)
            .Take(limit)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Location> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Locations
            .Include(l => l.Orders)
            .FirstOrDefaultAsync(cargo => cargo.Id == id, cancellationToken)
                     ?? throw new EntityNotFoundException("Местоположение не найдено");
    }

    public async Task<Location> AddAsync(Location entity, CancellationToken cancellationToken = default)
    {
        var entityEntry = await context.Locations.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entityEntry.Entity;
    }

    public async Task<Location> UpdateAsync(Location entity, CancellationToken cancellationToken = default)
    {
        var entityEntry = context.Locations.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entityEntry.Entity;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entityEntry = await GetByIdAsync(id, cancellationToken);
        context.Locations.Remove(entityEntry);
        await context.SaveChangesAsync(cancellationToken);
    }
}