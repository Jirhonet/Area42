using A42.Planning.Data.Dtos;

namespace A42.Planning.Domain.Helpers.Mappers
{
    internal static class LocationMapper
    {
        internal static LocationDto ToDto(this Location location)
        {
            LocationDto teamDto = new LocationDto()
            {
                Name = location.Name,
            };

            return teamDto;
        }

        internal static Location ToDomain(this LocationDto locationDto)
        {
            Location location = new Location(
                id: locationDto.Id,
                name: locationDto.Name
            );

            return location;
        }
    }
}
