namespace CargoOrders.Business.Models;

/// <summary>
/// Модель для обновления груза
/// </summary>
/// <param name="Weight">Вес</param>
public record UpdateCargoModel(double? Weight);