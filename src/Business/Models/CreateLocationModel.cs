namespace CargoOrders.Business.Models;

/// <summary>
/// Модель для создания местоположения
/// </summary>
/// <param name="Address">Адрес</param>
/// <param name="City">Город</param>
public record CreateLocationModel(string Address, string City);