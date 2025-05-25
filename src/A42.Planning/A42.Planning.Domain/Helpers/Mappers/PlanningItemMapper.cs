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
                LocationId = planningItem.Location.Id,
                TeamId = team.Id,
                Start = planningItem.Start.ToDateTimeOffset(date),
                End = planningItem.End.ToDateTimeOffset(date)
            };

            return planningItemDto;
        }

        internal static PlanningItem ToDomain(this PlanningItemDto planningItemDto)
        {
            PlanningItem planningItem = new PlanningItem(
                id: planningItemDto.Id,
                title: planningItemDto.Title,

            );

            return planningItem;
        }

        internal static IEnumerable<PlanningItem> ToDomain(this IEnumerable<PlanningItemDto> planningItemDtos)
        {
            return planningItemDtos.Select(planningItemDto => planningItemDto.ToDomain());
        }
    }
}
