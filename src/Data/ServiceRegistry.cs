using CargoOrders.Business.Repositories;
using CargoOrders.Data.Options;
using CargoOrders.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CargoOrders.Data;

public static class ServiceRegistry
{
    /// <summary>
    /// Добавление репозиториев
    /// </summary>
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICargoRepository, CargoRepository>();
        services.AddTransient<ILocationRepository, LocationRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        return services;
    }

    /// <summary>
    /// Добавление контекста БД, выбор провайдера баз данных
    /// </summary>
    private static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        AddOptions(services);

        services.AddDbContext<CargoOrderContext>((provider, builder) =>
        {
            var connOptions = provider.GetRequiredService<IOptions<ConnectionOptions>>();
            var providerOptions = provider.GetRequiredService<IOptions<DbProviderOptions>>();

            switch (providerOptions.Value.Provider)
            {
                case DbProvider.PostgreSql:
                    builder.UseNpgsql(connOptions.Value.CargoOrderDb,
                        b => b.MigrationsAssembly("Data.PostgreSql"));
                    break;

                default:
                    throw new NotSupportedException("Database provider not supported");
            }
        });
        return services;
    }

    private static void AddOptions(IServiceCollection services)
    {
        services.AddOptions<ConnectionOptions>()
            .BindConfiguration(ConnectionOptions.OptionsKey)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddOptions<DbProviderOptions>()
            .BindConfiguration(DbProviderOptions.OptionsKey)
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }

    /// <summary>
    /// Миграция базы данных
    /// </summary>
    public static async Task MigrateDatabaseAsync(
        this IServiceProvider serviceProvider,
        CancellationToken cancellationToken = default)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<CargoOrderContext>();
        await context.Database.MigrateAsync(cancellationToken);
    }

    /// <summary>
    /// Добавление репозиториев, контекста БД и выбор провайдера БД
    /// </summary>
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddRepositories();
        services.AddDbContext();
        return services;
    }

}