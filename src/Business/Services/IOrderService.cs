using CargoOrders.Business.Models;
using CargoOrders.Domain.Entities;

namespace CargoOrders.Business.Services;

/// <summary>
/// Сервис для работы с заказами
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Добавление заказа
    /// </summary>
    /// <param name="createModel">Модель для создания заказа</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public Task<Order> AddAsync(CreateOrderModel createModel, CancellationToken cancellationToken = default);

    /// <summary>
    /// Изменение заказа
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <param name="updateModel">Модель для обновления заказа</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public Task UpdateAsync(Guid id, UpdateOrderModel updateModel, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удаление заказа
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получение всех заказов с пагинацией
    /// </summary>
    /// <param name="offset">Сколько заказов пропустить</param>
    /// <param name="limit">Сколько заказов вернуть</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public Task<IReadOnlyList<Order>> GetAllAsync(
        int? offset, 
        int? limit, 
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Получение заказа по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}