using A42.Planning.Data.Abstractions;
using A42.Planning.Data.Dtos;
using A42.Planning.Data.Repositories;
using A42.Planning.Domain.Helpers.Mappers;

namespace A42.Planning.Domain.Services
{
    public class LocationService : ILocationService
    {
        private readonly LocationRepository _locationRepository;

        public LocationService(LocationRepository LocationRepository)
        {
            _locationRepository = LocationRepository;
        }

        /// <inheritdoc />
        public IEnumerable<Location> Get()
        {
            IEnumerable<LocationDto> locationDtos = _locationRepository.Get();
            return locationDtos.Select(locationDto => locationDto.ToDomain());
        }

        /// <inheritdoc />
        public void Add(Location location)
        {
            LocationDto locationDto = location.ToDto();
            _locationRepository.Insert(locationDto);
        }
    }
}
