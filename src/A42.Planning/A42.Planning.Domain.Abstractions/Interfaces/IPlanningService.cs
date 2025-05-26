namespace A42.Planning.Domain.Abstractions.Interfaces
{
    public interface IPlanningService
    {
        public Planning Get(DateOnly date, Team team);

        public void Add(Planning planning, PlanningItem planningItem);
    }
}
