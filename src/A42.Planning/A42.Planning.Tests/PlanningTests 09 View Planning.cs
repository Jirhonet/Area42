using A42.Planning.Domain;
using A42.Planning.Tests.Mock;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace A42.Planning.Tests
{
    public partial class PlanningTests
    {
        [TestMethod("P 09a: View planning as planner")]
        public void P_09a_ViewPlanning_AsPlanner()
        {
            // Arrange
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            Team team = new Team(1, "Team", new List<Employee>());
            Location location = new Location(1, "Location");
            PlanningItem item = new PlanningItem(1, "Test Item", location, new TimeOnly(10, 0), new TimeOnly(11, 0));
            var planning = new Domain.Planning(date, team, new List<PlanningItem> { item });
            _planningService.Plannings.Add(planning);

            // Act
            var result = _planningService.Get(date, team);

            // Assert
            result.Should().NotBeNull();
            result.Date.Should().Be(date);
            result.Team.Should().Be(team);
            result.Items.Should().Contain(item);
        }

        [TestMethod("P 09b: View planning as team member for non-member team")]
        public void P_09b_ViewPlanning_AsTeamMember_ForNonMemberTeam()
        {
            // Arrange
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            Employee employee = new Employee(1, "Team Member");
            Team team = new Team(1, "Team", new List<Employee>());
            Team otherTeam = new Team(2, "Other Team", new List<Employee> { employee });
            Location location = new Location(1, "Location");
            PlanningItem item = new PlanningItem(1, "Test Item", location, new TimeOnly(10, 0), new TimeOnly(11, 0));
            var planning = new Domain.Planning(date, team, new List<PlanningItem> { item });
            _planningService.Plannings.Add(planning);

            // Act
            Action action = () => _planningService.Get(date, team);

            // Assert
            action.Should().Throw<UnauthorizedAccessException>()
                .WithMessage("You are not authorized to view this team's planning.");
        }

        [TestMethod("P 09c: View planning as team member for member team")]
        public void P_09c_ViewPlanning_AsTeamMember_ForMemberTeam()
        {
            // Arrange
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            Employee employee = new Employee(1, "Team Member");
            Team team = new Team(1, "Team", new List<Employee> { employee });
            Location location = new Location(1, "Location");
            PlanningItem item = new PlanningItem(1, "Test Item", location, new TimeOnly(10, 0), new TimeOnly(11, 0));
            var planning = new Domain.Planning(date, team, new List<PlanningItem> { item });
            _planningService.Plannings.Add(planning);

            // Act
            var result = _planningService.Get(date, team);

            // Assert
            result.Should().NotBeNull();
            result.Date.Should().Be(date);
            result.Team.Should().Be(team);
            result.Items.Should().Contain(item);
        }
    }
} 