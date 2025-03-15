namespace CargoOrders.Business.Models;

/// <summary>
/// Модель для обновления заказа
/// </summary>
/// <param name="PickupAt">Время забора заказа</param>
public record UpdateOrderModel(DateTimeOffset? PickupAt);