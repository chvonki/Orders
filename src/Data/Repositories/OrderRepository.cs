using CargoOrders.Business.Repositories;
using CargoOrders.Data.Exceptions;
using CargoOrders.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CargoOrders.Data.Repositories;

internal sealed class OrderRepository : IOrderRepository
{
    private readonly CargoOrderContext context;

    public OrderRepository(CargoOrderContext context)
    {
        this.context = context;
    }

    public async Task<IReadOnlyList<Order>> GetAllAsync(int offset = 0, int limit = 10, CancellationToken cancellationToken = default)
    {
        return await context.Orders
            .Skip(offset)
            .Take(limit)
            .ToListAsync(cancellationToken);
    }

    public async Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Orders
            .FirstOrDefaultAsync(cargo => cargo.Id == id, cancellationToken)
            ?? throw new EntityNotFoundException("Заказ не найден");
    }

    public async Task<Order> AddAsync(Order entity, CancellationToken cancellationToken = default)
    {
        var entityEntry = await context.Orders.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entityEntry.Entity;
    }

    public async Task<Order> UpdateAsync(Order entity, CancellationToken cancellationToken = default)
    {
        var entityEntry = context.Orders.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entityEntry.Entity;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entityEntry = await GetByIdAsync(id, cancellationToken);
        context.Orders.Remove(entityEntry);
        await context.SaveChangesAsync(cancellationToken);
    }
}