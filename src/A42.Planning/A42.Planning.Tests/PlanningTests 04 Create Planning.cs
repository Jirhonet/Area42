using A42.Planning.Domain;
using FluentAssertions;

namespace A42.Planning.Tests
{
    public partial class PlanningTests
    {
        [TestMethod("PT 04a: Create planning without items")]
        public void PT_04a_Create_Planning()
        {
            // Arrange
            DateOnly date = new DateOnly(2025, 1, 1);
            Team team = new Team(1, "Team", new List<Employee>());

            // Act
            Domain.Planning planning = new Domain.Planning(date, team, new List<PlanningItem>());

            // Assert
            planning.Should().NotBeNull();
            planning.Date.Should().Be(date);
            planning.Team.Should().Be(team);
            planning.Items.Should().BeEmpty();
        }

        [TestMethod("PT 04b: Create planning with items")]
        public void PT_04b_Create_Planning_With_Items()
        {
            // Arrange
            DateOnly date = new DateOnly(2025, 1, 1);
            Team team = new Team(1, "Team", new List<Employee>());
            Location location = new Location(1, "Location 1");
            PlanningItem item1 = new PlanningItem(1, "Item 1", location, new TimeOnly(10, 0), new TimeOnly(11, 0));
            PlanningItem item2 = new PlanningItem(2, "Item 2", location, new TimeOnly(11, 0), new TimeOnly(12, 0));

            // Act
            Domain.Planning planning = new Domain.Planning(date, team, new List<PlanningItem> { item1, item2 });

            // Assert
            planning.Should().NotBeNull();
            planning.Date.Should().Be(date);
            planning.Team.Should().Be(team);
            planning.Items.Should().HaveCount(2);
            planning.Items.Should().Contain(item1);
            planning.Items.Should().Contain(item2);
        }
    }
}
