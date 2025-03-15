using CargoOrders.Business.Models;
using CargoOrders.Business.Repositories;
using CargoOrders.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CargoOrders.Business.Services;

internal sealed class CargoService : ICargoService
{
    private readonly ICargoRepository cargoRepository;
    private readonly ILogger logger;

    public CargoService(
        ICargoRepository cargoRepository, 
        ILogger<CargoService> logger)
    {
        this.cargoRepository = cargoRepository;
        this.logger = logger;
    }

    public async Task<Cargo> AddAsync(CreateCargoModel createModel, CancellationToken cancellationToken = default)
    {
        var cargo = Cargo.Create(createModel.Weight);
        await cargoRepository.AddAsync(cargo, cancellationToken);
        
        logger.LogInformation("Cargo {cargo.Id} was added", cargo.Id);
        
        return cargo;
    }

    public async Task UpdateAsync(Guid id, UpdateCargoModel updateModel, CancellationToken cancellationToken = default)
    {
        var existingCargo = await cargoRepository.GetByIdAsync(id, cancellationToken);

        await cargoRepository.UpdateAsync(existingCargo, cancellationToken);
        
        logger.LogInformation("Cargo {existingCargo.Id} was updated", existingCargo.Id);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await cargoRepository.DeleteAsync(id, cancellationToken);
        logger.LogInformation("Cargo {id} was deleted", id);
    }

    public async Task<Cargo> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    { 
        return await cargoRepository.GetByIdAsync(id, cancellationToken);
    }
}