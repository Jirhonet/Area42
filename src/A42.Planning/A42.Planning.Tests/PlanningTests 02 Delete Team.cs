using A42.Planning.Domain;
using FluentAssertions;

namespace A42.Planning.Tests
{
    public partial class PlanningTests
    {
        [TestMethod("P 02: Delete team not used in planning")]
        public void P_02_DeleteTeam_NotUsedInPlanning()
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
    }
}
