namespace A42.Planning.Domain
{
    public class Team
    {
        private List<Employee> _employees;

        public Team(string name, List<Employee> employees)
        {
            Name = name;
            _employees = employees;
        }

        public string Name { get; private init; }
        public IReadOnlyList<Employee> Employees
            => _employees;

        public void AddEmployee(Employee employee)
        {
            if (Employees.Any(e => e.Id == employee.Id))
                throw new InvalidOperationException($"Employee '{employee.FullName}' is already in team {Name}.");

            _employees.Add(employee);
        }
    }
}
