namespace A42.Planning.Domain
{
    public class Team
    {
        private List<Employee> _employees;

        public Team(int id, string name, List<Employee> employees)
        {
            Id = id;
            Name = name;
            _employees = employees;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyList<Employee> Employees
            => _employees;

        public bool AddEmployee(Employee employee)
        {
            if (Employees.Any(e => e.Id == employee.Id))
                throw new InvalidOperationException($"Employee '{employee.FullName}' is already in team {Name}.");

            _employees.Add(employee);

            return true;
        }
    }
}
