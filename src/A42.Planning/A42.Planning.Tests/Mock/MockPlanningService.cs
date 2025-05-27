using A42.Planning.Data.Abstractions;
using A42.Planning.Domain;

namespace A42.Planning.Tests.Mock
{
    public class MockPlanningService : IPlanningService
    {
        internal List<Domain.Planning> Plannings { get; private set; } = new List<Domain.Planning>();

        public Domain.Planning Get(DateOnly date, Team team)
        {
            return Plannings.First(p => p.Date == date && p.Team == team);
        }

        public void Add(Domain.Planning planning, PlanningItem planningItem)
        {
            planning.AddItem(planningItem);
        }
    }
}
