using A42.Planning.Domain;
using FluentAssertions;

namespace A42.Planning.Tests
{
    public partial class PlanningTests
    {
        [TestMethod("P 03a: Add team member to team")]
        public void P_03a_AddTeamMember_ToTeam()
        {
            // Arrange
            Team team = new Team(1, "Team", new List<Employee>());
            Employee employee = new Employee(1, "New Employee");

            // Act
            bool result = team.AddEmployee(employee);

            // Assert
            result.Should().BeTrue();
            team.Employees.Should().Contain(employee);
        }

        [TestMethod("P 03b: Add existing team member to team")]
        public void P_03b_AddTeamMember_AlreadyInTeam()
        {
            // Arrange
            Employee employee = new Employee(1, "Existing Employee");
            Team team = new Team(1, "Team", new List<Employee> { employee });

            // Act
            Action action = () => team.AddEmployee(employee);

            // Assert
            action.Should().Throw<InvalidOperationException>()
                .WithMessage($"Employee '{employee.FullName}' is already in team '{team.Name}'.");
        }
    }
}