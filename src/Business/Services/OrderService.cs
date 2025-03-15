using CargoOrders.Business.Models;
using CargoOrders.Business.Repositories;
using CargoOrders.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CargoOrders.Business.Services;

internal sealed class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;
    private readonly ICargoRepository cargoRepository;
    private readonly ILocationRepository cargoService;

    private readonly ILogger logger;

    public OrderService(
        IOrderRepository orderRepository, 
        ICargoRepository cargoRepository, 
        ILocationRepository cargoService, 
        ILogger<OrderService> logger)
    {
        this.orderRepository = orderRepository;
        this.cargoRepository = cargoRepository;
        this.cargoService = cargoService;
        this.logger = logger;
    }

    public Task<Order> AddAsync(CreateOrderModel createModel, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, UpdateOrderModel updateModel, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Order>> GetAllAsync(int? offset, int? limit, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}