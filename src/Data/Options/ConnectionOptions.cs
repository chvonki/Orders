using System.ComponentModel.DataAnnotations;

namespace CargoOrders.Data.Options; 

/// <summary>
/// Настройки для строки подключения к базе данных
/// </summary>
public sealed class ConnectionOptions
{
    /// <summary>
    /// Ключ настройки в конфигурационном файле
    /// </summary>
    public const string OptionsKey = "ConnectionStrings";

    /// <summary>
    /// Строка для подключения к БД
    /// </summary>
    [Required]
    public string? CargoOrderDb { get; set; }
}
