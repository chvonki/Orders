using CargoOrders.Business.Repositories;
using CargoOrders.Data.Exceptions;
using CargoOrders.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CargoOrders.Data.Repositories;

internal sealed class CargoRepository : ICargoRepository
{
    private readonly CargoOrderContext context;
    
    public CargoRepository(CargoOrderContext context)
    {
        this.context = context;
    }
    
    public async Task<IReadOnlyList<Cargo>> GetAllAsync(int offset = 0, int limit = 10, CancellationToken cancellationToken = default)
    {
        return await context.Cargoes
            .Include(c => c.Orders)
            .Skip(offset)
            .Take(limit)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Cargo> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Cargoes
            .Include(c => c.Orders)
            .FirstOrDefaultAsync(cargo => cargo.Id == id, cancellationToken) 
                     ?? throw new EntityNotFoundException("Груз не найден");
    }

    public async Task<Cargo> AddAsync(Cargo entity, CancellationToken cancellationToken = default)
    {
        var entityEntry = await context.Cargoes.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entityEntry.Entity;
    }

    public async Task<Cargo> UpdateAsync(Cargo entity, CancellationToken cancellationToken = default)
    {
        var entityEntry = context.Cargoes.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entityEntry.Entity;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entityEntry = await GetByIdAsync(id, cancellationToken);
        context.Cargoes.Remove(entityEntry);
        await context.SaveChangesAsync(cancellationToken);
    }
}