using CargoOrders.Data.Repositories;

namespace CargoOrders.Business.Services;

internal sealed class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }
}