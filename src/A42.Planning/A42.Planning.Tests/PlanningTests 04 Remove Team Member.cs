using A42.Planning.Domain;
using FluentAssertions;

namespace A42.Planning.Tests
{
    public partial class PlanningTests
    {
        [TestMethod("P 04a: Remove team member from team")]
        public void P_04a_RemoveTeamMember_FromTeam()
        {
            // Arrange
            Employee employee = new Employee(1, "Employee to Remove");
            Team team = new Team(1, "Team", new List<Employee> { employee });

            // Act
            bool result = team.RemoveEmployee(employee);

            // Assert
            result.Should().BeTrue();
            team.Employees.Should().NotContain(employee);
        }
    }
}