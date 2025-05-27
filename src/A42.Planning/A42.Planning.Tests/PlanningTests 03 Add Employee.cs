using A42.Planning.Domain;
using FluentAssertions;

namespace A42.Planning.Tests
{
    public partial class PlanningTests
    {
        [TestMethod("PT 03a: Add employee")]
        public void PT_03a_Add_Employee()
        {
            // Arrange
            Employee employee = new Employee(1, "Employee");
            Team team = new Team(1, "Team", new List<Employee>());
            _teamService.Teams.Add(team);

            // Act
            bool result = team.AddEmployee(employee);

            // Assert
            result.Should().BeTrue();
            team.Should().NotBeNull();
            team.Id.Should().Be(1);
            team.Name.Should().Be("Team");
            team.Employees.Should().HaveCount(1);
            team.Employees.Should().Contain(employee);
            employee.Should().NotBeNull();
            employee.Id.Should().Be(1);
            employee.FullName.Should().Be("Employee");
        }

        [TestMethod("PT 03b: Add existing employee")]
        public void PT_03b_Add_Existing_Employee()
        {
            // Arrange
            Employee employee = new Employee(1, "Employee");
            Team team = new Team(1, "Team", new List<Employee>()
            {
                employee
            });
            _teamService.Teams.Add(team);

            // Act
            Func<bool> act = () => team.AddEmployee(employee);

            // Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage($"Employee '{employee.FullName}' is already in team '{team.Name}'.");
        }
    }
}
