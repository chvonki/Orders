using CargoOrders.Business.Models;
using CargoOrders.Business.Repositories;
using CargoOrders.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CargoOrders.Business.Services;

internal sealed class LocationService : ILocationService
{
    private readonly ILocationRepository locationRepository;
    private readonly ILogger logger;

    public LocationService(
        ILocationRepository locationRepository,
        ILogger<LocationService> logger)
    {
        this.locationRepository = locationRepository;
        this.logger = logger;
    }

    public async Task<Location> AddAsync(CreateLocationModel createModel, CancellationToken cancellationToken = default)
    {
        var location = Location.Create(createModel.Address, createModel.City);
        await locationRepository.AddAsync(location, cancellationToken);
        
        logger.LogInformation("Location {location.Id} was added", location.Id);
        
        return location;
    }

    public async Task UpdateAsync(Guid id, UpdateLocationModel updateModel, CancellationToken cancellationToken = default)
    {
        var existingLocation = await locationRepository.GetByIdAsync(id, cancellationToken);

        await locationRepository.UpdateAsync(existingLocation, cancellationToken);
        
        logger.LogInformation("Location {existingLocation.Id} was updated", existingLocation.Id);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await locationRepository.DeleteAsync(id, cancellationToken);
        logger.LogInformation("Location {id} was deleted", id);
    }

    public async Task<Location> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await locationRepository.GetByIdAsync(id, cancellationToken);
    }
}