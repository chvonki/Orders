namespace CargoOrders.Domain.Entities;

/// <summary>
/// Груз
/// </summary>
public sealed class Cargo : IEntity
{
    private Cargo(Guid id, double weight)
    {
        Id = id;
        Weight = weight;
    }

    /// <summary>
    /// Идентификатор груза
    /// </summary>
    public Guid Id { get; }
    
    /// <summary>
    /// Вес
    /// </summary>
    public double Weight { get; set; }
    
    /// <summary>
    /// Навигационное свойство для заказов
    /// </summary>
    public List<Order> Orders { get; set; } = [];
    
    /// <summary>
    /// Метод для создания экземпляра груза
    /// </summary>
    /// <param name="id">Идентификатор груза</param>
    /// <param name="weight">Вес груза</param>
    /// <returns></returns>
    public static Cargo Create(Guid id, double weight)
    {
        Validate(weight);
        return new Cargo(id, weight);
    }
    
    private static void Validate(double weight)
    {
        if (weight <= 0)
        {
            throw new ArgumentException($"Невозможно задать вес со значением weight = {weight}");
        }
    }
}