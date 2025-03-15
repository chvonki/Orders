using CargoOrders.Business.Models;
using CargoOrders.Domain.Entities;

namespace CargoOrders.Business.Services;

/// <summary>
/// Сервис для работы с местоположениями
/// </summary>
public interface ILocationService
{
    /// <summary>
    /// Добавление местоположения
    /// </summary>
    /// <param name="createModel">Модель для создания заказа</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public Task<Location> AddAsync(CreateLocationModel createModel, CancellationToken cancellationToken = default);

    /// <summary>
    /// Изменение местоположения
    /// </summary>
    /// <param name="id">Идентификатор местоположения</param>
    /// <param name="updateModel">Модель для обновления местоположения</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public Task UpdateAsync(Guid id, UpdateLocationModel updateModel, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удаление местоположения
    /// </summary>
    /// <param name="id">Идентификатор местоположения</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получение местоположения по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор местоположения</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public Task<Location> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}