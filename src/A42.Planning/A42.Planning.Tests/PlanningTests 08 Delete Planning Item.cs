using A42.Planning.Domain;
using A42.Planning.Tests.Mock;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace A42.Planning.Tests
{
    public partial class PlanningTests
    {
        [TestMethod("P 08: Delete planning item")]
        public void P_08_DeletePlanningItem()
        {
            // Arrange
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            Team team = new Team(1, "Team", new List<Employee>());
            Location location = new Location(1, "Location");
            PlanningItem item = new PlanningItem(1, "Test Item", location, new TimeOnly(10, 0), new TimeOnly(11, 0));
            var planning = new Domain.Planning(date, team, new List<PlanningItem> { item });
            _planningService.Plannings.Add(planning);

            // Act
            _planningService.Remove(item);

            // Assert
            planning.Items.Should().NotContain(item);
        }
    }
} 