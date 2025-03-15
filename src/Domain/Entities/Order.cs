namespace CargoOrders.Domain.Entities;

/// <summary>
/// Заказ
/// </summary>
public sealed class Order : IEntity
{
    private Order(
        Guid id,
        Guid senderLocationId, 
        Guid receiverLocationId, 
        Guid cargoId, 
        DateTimeOffset pickupDate)
    {
        SenderLocationId = senderLocationId;
        ReceiverLocationId = receiverLocationId;
        CargoId = cargoId;
        PickupAt = pickupDate;
    }

    /// <summary>
    /// Создание заказа
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="senderLocationId">Идентификатор местоположения отправителя</param>
    /// <param name="receiverLocationId">Идентификатор местоположения получателя</param>
    /// <param name="cargoId">Идентификатор груза</param>
    /// <param name="pickupDate">Дата забора груза</param>
    /// <returns></returns>
    public static Order Create(
        Guid id,
        Guid senderLocationId,
        Guid receiverLocationId,
        Guid cargoId,
        DateTimeOffset pickupDate)
    {
        return new Order(Guid.NewGuid(), senderLocationId, receiverLocationId, cargoId, pickupDate);
    }
    
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Идентификатор местоположения отправителя
    /// </summary>
    public Guid SenderLocationId { get; private set; }
    
    /// <summary>
    /// Навигационное свойство
    /// </summary>
    public Location SenderLocation { get; private set; }
    
    /// <summary>
    /// Идентификатор местоположения получателя
    /// </summary>
    public Guid ReceiverLocationId { get; private set; }
    
    /// <summary>
    /// Навигационное свойство
    /// </summary>
    public Location ReceiverLocation { get; private set; }
    
    /// <summary>
    /// Идентификатор груза
    /// </summary>
    public Guid CargoId { get; private set; }
    
    /// <summary>
    /// Навигационное свойство
    /// </summary>
    public Cargo Cargo { get; private set; }
    
    /// <summary>
    /// Дата забора груза
    /// </summary>
    public DateTimeOffset PickupAt { get; private set; }

}