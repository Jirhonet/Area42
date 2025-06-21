using A42.Planning.Data.Dtos;

namespace A42.Planning.Domain.Helpers.Mappers
{
    internal static class PlanningItemMapper
    {
        internal static PlanningItemDto ToDto(this PlanningItem planningItem, Team team, DateOnly date)
        {
            PlanningItemDto planningItemDto = new PlanningItemDto()
            {
                Id = planningItem.Id,
                Title = planningItem.Title,
                LocationId = planningItem.Location.Id,
                TeamId = team.Id,
                Start = planningItem.Start.ToDateTimeOffset(date),
                End = planningItem.End.ToDateTimeOffset(date)
            };

            return planningItemDto;
        }

        internal static PlanningItem ToDomain(this PlanningItemDto planningItemDto, LocationDto locationDto)
        {
            PlanningItem planningItem = new PlanningItem(
                id: planningItemDto.Id,
                title: planningItemDto.Title,
                location: locationDto.ToDomain(),
                start: planningItemDto.Start.ToTimeOnly(),
                end: planningItemDto.End.ToTimeOnly()
            );

            return planningItem;
        }

        internal static IEnumerable<PlanningItem> ToDomain(this IEnumerable<PlanningItemDto> planningItemDtos, IEnumerable<LocationDto> locationDtos)
        {
            return planningItemDtos.Select(planningItemDto => planningItemDto.ToDomain(locationDtos.FirstOrDefault(l => l.Id == planningItemDto.LocationId) ?? throw new Exception("No location found for planning item.")));
        }
    }
}
