namespace CargoOrders.Domain.Entities;

/// <summary>
/// Местоположение
/// </summary>
public sealed class Location : IEntity
{
    public Location(Guid id, string address, string city)
    {
        Id = id;
        Address = address;
        City = city;
    }

    /// <summary>
    /// Идентификатор местоположения
    /// </summary>
    public Guid Id { get; }
    
    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; set; }
    
    /// <summary>
    /// Город
    /// </summary>
    public string City { get; set; }
    
    /// <summary>
    /// Навигационное свойство для заказов
    /// </summary>
    public List<Order> Orders { get; set; } = [];
}