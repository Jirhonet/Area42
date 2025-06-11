using A42.Planning.Domain;
using A42.Planning.Tests.Mock;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace A42.Planning.Tests
{
    public partial class PlanningTests
    {
        [TestMethod("P 06a: Delete location not used in planning")]
        public void P_06a_DeleteLocation_NotUsedInPlanning()
        {
            // Arrange
            Location location = new Location(1, "Location to Delete");
            _locationService.Add(location);

            // Act
            _locationService.Remove(location);

            // Assert
            var locations = _locationService.Get();
            locations.Should().NotContain(l => l.Id == location.Id);
        }

        [TestMethod("P 06b: Delete location used in planning")]
        public void P_06b_DeleteLocation_UsedInPlanning()
        {
            // Arrange
            Location location = new Location(1, "Location in Planning");
            _locationService.Add(location);
            Team team = new Team(1, "Team", new List<Employee>());
            PlanningItem item = new PlanningItem(1, "Test Item", location, new TimeOnly(10, 0), new TimeOnly(11, 0));
            var planning = new Domain.Planning(DateOnly.FromDateTime(DateTime.Now), team, new List<PlanningItem> { item });
            _planningService.Plannings.Add(planning);

            // Act
            Action action = () => _locationService.Remove(location);

            // Assert
            action.Should().Throw<InvalidOperationException>()
                .WithMessage($"Cannot delete location '{location.Name}' as it is used in planning.");
        }
    }
} 