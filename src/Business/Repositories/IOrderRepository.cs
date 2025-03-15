using CargoOrders.Domain.Entities;

namespace CargoOrders.Business.Repositories;

/// <summary>
/// Репозиторий для заказов
/// </summary>
public interface IOrderRepository : IRepository<Order>
{
}