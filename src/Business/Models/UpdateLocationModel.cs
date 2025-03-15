namespace CargoOrders.Business.Models;

/// <summary>
/// Модель для обновления местоположения
/// </summary>
/// <param name="Address"></param>
/// <param name="City"></param>
public record UpdateLocationModel(string? Address, string? City);