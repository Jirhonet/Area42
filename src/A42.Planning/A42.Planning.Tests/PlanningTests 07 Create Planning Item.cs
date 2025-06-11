using A42.Planning.Domain;
using A42.Planning.Tests.Mock;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace A42.Planning.Tests
{
    public partial class PlanningTests
    {
        [TestMethod("P 07a: Add planning item to free time slot")]
        public void P_07a_AddPlanningItem_ToFreeTimeSlot()
        {
            // Arrange
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            Team team = new Team(1, "Team", new List<Employee>());
            Location location = new Location(1, "Location");
            PlanningItem item = new PlanningItem(1, "Test Item", location, new TimeOnly(10, 0), new TimeOnly(11, 0));
            var planning = new Domain.Planning(date, team, new List<PlanningItem>());
            _planningService.Plannings.Add(planning);

            // Act
            _planningService.Add(planning, item);

            // Assert
            planning.Items.Should().Contain(item);
        }

        [TestMethod("P 07b: Add planning item to occupied time slot")]
        public void P_07b_AddPlanningItem_ToOccupiedTimeSlot()
        {
            // Arrange
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            Team team = new Team(1, "Team", new List<Employee>());
            Location location = new Location(1, "Location");
            PlanningItem existingItem = new PlanningItem(1, "Existing Item", location, new TimeOnly(10, 0), new TimeOnly(11, 0));
            PlanningItem newItem = new PlanningItem(2, "New Item", location, new TimeOnly(10, 0), new TimeOnly(11, 0));
            var planning = new Domain.Planning(date, team, new List<PlanningItem> { existingItem });
            _planningService.Plannings.Add(planning);

            // Act
            Action action = () => _planningService.Add(planning, newItem);

            // Assert
            action.Should().Throw<InvalidOperationException>()
                .WithMessage("Item overlaps with existing items.");
        }
    }
} 