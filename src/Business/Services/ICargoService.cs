using CargoOrders.Business.Models;
using CargoOrders.Domain.Entities;

namespace CargoOrders.Business.Services;

/// <summary>
/// Сервис для работы с грузами
/// </summary>
public interface ICargoService
{
    /// <summary>
    /// Добавление груза
    /// </summary>
    /// <param name="createModel">Модель для создания груза</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public Task<Cargo> AddAsync(CreateCargoModel createModel, CancellationToken cancellationToken = default);

    /// <summary>
    /// Изменение груза
    /// </summary>
    /// <param name="id">Идентификатор груза</param>
    /// <param name="updateModel">Модель для обновления груза</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public Task UpdateAsync(Guid id, UpdateCargoModel updateModel, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удаление груза
    /// </summary>
    /// <param name="id">Идентификатор груза</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получение груза по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор груза</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public Task<Cargo> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}