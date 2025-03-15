using CargoOrders.Domain;

namespace CargoOrders.Business;

/// <summary>
/// Репозиторий для сущностей, реализующих <see cref="IEntity"/>
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
public interface IRepository<TEntity> where TEntity : IEntity
{
    /// <summary>
    /// Получить список сущностей
    /// </summary>
    /// <param name="offset">Начиная с элемента</param>
    /// <param name="limit">Заканчивая элементом</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Список сущностей.</returns>
    Task<IReadOnlyList<TEntity>> GetAllAsync(int offset = 0, int limit = 10, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить сущность по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Сущность.</returns>
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Добавить сущность
    /// </summary>
    /// <param name="entity">Сущность</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Добавленная сущность</returns>
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновить сущность.
    /// </summary>
    /// <param name="entity">Обновленная сущность.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns><see cref="Task"/>.</returns>
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удалить сущность.
    /// </summary>
    /// <param name="id">Идентификатор сущности.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns><see cref="Task"/>.</returns>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}