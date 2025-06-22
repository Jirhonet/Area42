using A42.Planning.Data.Abstractions;
using A42.Planning.Data.Dtos;
using A42.Planning.Data.Repositories;
using A42.Planning.Domain.Helpers.Mappers;

namespace A42.Planning.Domain.Services
{
    public class PlanningService : IPlanningService
    {
        private readonly PlanningItemRepository _planningItemRepository;
        private readonly LocationRepository _locationRepository;

        public PlanningService(PlanningItemRepository planningItemRepository, LocationRepository locationRepository)
        {
            _planningItemRepository = planningItemRepository;
            _locationRepository = locationRepository;
        }

        /// <inheritdoc />
        public Planning Get(DateOnly date, Team team)
        {
            IEnumerable<PlanningItem> items = GetPlanningItems(date, team);

            Planning planning = new Planning(
                date: date,
                team: team,
                items: items
            );

            return planning;
        }

        private IEnumerable<PlanningItem> GetPlanningItems(DateOnly date, Team team)
        {
            IEnumerable<PlanningItemDto> planningItemDtos = _planningItemRepository.Get(date.ToDateTime(new TimeOnly()), team.Id);
            IEnumerable<LocationDto> locationDtos = _locationRepository.GetByIds(planningItemDtos.Select(p => p.LocationId));
            return planningItemDtos.ToDomain(locationDtos);
        }

        /// <inheritdoc />
        public void Add(Planning planning, PlanningItem planningItem)
        {
            if (!planning.AddItem(planningItem))
                throw new Exception("Unable to add planning item");

            PlanningItemDto planningItemDto = planningItem.ToDto(planning.Team, planning.Date);
            _planningItemRepository.Insert(planningItemDto);
        }

        /// <inheritdoc />
        public void Remove(PlanningItem planningItem)
        {
            _planningItemRepository.Delete(planningItem.Id);
        }
    }
}
