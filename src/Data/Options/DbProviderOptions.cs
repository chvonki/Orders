using System.ComponentModel.DataAnnotations;

namespace CargoOrders.Data.Options;

/// <summary>
/// Настройки для провайдера баз данных
/// </summary>
public sealed class DbProviderOptions
{
    /// <summary>
    /// Ключ настройки в конфигурационном файле
    /// </summary>
    public const string OptionsKey = "DbProvider";

    /// <summary>
    /// Провайдер базы данных
    /// </summary>
    [Required]
    public DbProvider? Provider { get; set; }
}
