using A42.Planning.Domain;
using FluentAssertions;

namespace A42.Planning.Tests
{
    public partial class PlanningTests
    {
        [TestMethod("P 02a: Delete team not used in planning")]
        public void P_02a_DeleteTeam_NotUsedInPlanning()
        {
            // Arrange
            Team team = new Team(1, "Team to Delete", new List<Employee>());
            _teamService.Add(team);

            // Act
            _teamService.Remove(team);

            // Assert
            IEnumerable<Team> teams = _teamService.Get();
            teams.Should().NotContain(t => t.Id == team.Id);
        }

        [TestMethod("P 02b: Delete team used in planning")]
        public void P_02b_DeleteTeam_UsedInPlanning()
        {
            // Arrange
            Team team = new Team(1, "Team in Planning", new List<Employee>());
            _teamService.Add(team);
            Domain.Planning planning = new Domain.Planning(DateOnly.FromDateTime(DateTime.Now), team, new List<PlanningItem>());
            _planningService.Plannings.Add(planning);

            // Act
            Action action = () => _teamService.Remove(team);

            // Assert
            action.Should().Throw<InvalidOperationException>()
                .WithMessage($"Cannot delete team '{team.Name}' as it is used in planning.");
        }
    }
}
