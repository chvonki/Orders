namespace CargoOrders.Domain;

/// <summary>
/// Сущность с идентификатором типа Guid
/// </summary>
public interface IEntity
{
    /// <summary>
    /// ID объекта
    /// </summary>
    public Guid Id { get; }
}