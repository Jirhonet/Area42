using A42.Planning.Domain;
using FluentAssertions;

namespace A42.Planning.Tests
{
    public partial class PlanningTests
    {
        [TestMethod("P 01a: Create team with unique name")]
        public void P_01a_CreateTeam_WithUniqueName()
        {
            // Arrange
            Employee employee1 = new Employee(1, "Employee 1");
            Employee employee2 = new Employee(2, "Employee 2");
            Team team1 = new Team(1, "Team 1", new List<Employee>() {
                employee1,
                employee2,
            });
            _teamService.Teams.Add(team1);
            Team team2 = new Team(2, "Team 2", new List<Employee>());
            _teamService.Teams.Add(team2);

            // Act
            IEnumerable<Team> teams = _teamService.Get();

            // Assert
            teams.Should().NotBeNullOrEmpty();
            teams.Should().HaveCount(2);

            teams.Should().Contain(team1);
            team1.Should().NotBeNull();
            team1.Id.Should().Be(1);
            team1.Name.Should().Be("Team 1");
            team1.Employees.Should().HaveCount(2);
            team1.Employees.Should().Contain(employee1);
            team1.Employees.Should().Contain(employee2);

            teams.Should().Contain(team2);
            team2.Should().NotBeNull();
            team2.Id.Should().Be(2);
            team2.Name.Should().Be("Team 2");
            team2.Employees.Should().HaveCount(0);

        }

        [TestMethod("P 01b: Create team with existing name")]
        public void P_01b_CreateTeam_WithExistinName()
        {
            // Arrange
            string teamName = "Existing Team";
            Team existingTeam = new Team(1, teamName, new List<Employee>());
            _teamService.Add(existingTeam);

            // Act
            Action action = () => _teamService.Add(new Team(2, teamName, new List<Employee>()));

            // Assert
            action.Should().Throw<InvalidOperationException>()
                .WithMessage($"A team with name '{teamName}' already exists.");
        }
    }
}
