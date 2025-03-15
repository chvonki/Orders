namespace CargoOrders.Business.Models;

/// <summary>
/// Модель для создания заказа
/// </summary>
/// <param name="SenderLocationId">Идентификатор местоположения отправителя</param>
/// <param name="ReceiverLocationId">Идентификатор местоположения получателя</param>
/// <param name="CargoId">Идентификатор груза</param>
/// <param name="PickupAt">Время забора заказа</param>
public record CreateOrderModel(
    Guid SenderLocationId,
    Guid ReceiverLocationId,
    Guid CargoId,
    DateTimeOffset PickupAt);