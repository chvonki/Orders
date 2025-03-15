namespace CargoOrders.Domain.Entities;

/// <summary>
/// Местоположение
/// </summary>
public sealed class Location : IEntity
{
    private Location(Guid id, string address, string city)
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

    public static Location Create(string address, string city)
    {
        return new Location(Guid.NewGuid(), address, city);
    }
}