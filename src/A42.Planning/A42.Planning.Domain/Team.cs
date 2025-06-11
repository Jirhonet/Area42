using System.Collections.ObjectModel;

namespace A42.Planning.Domain
{
    public class Team
    {
        private List<Employee> _employees;

        public Team(int id, string name, IEnumerable<Employee> employees)
        {
            Id = id;
            Name = name;
            _employees = new List<Employee>(employees);
        }

        public int Id { get; private set; }
        public string Name { get; private init; }
        public ReadOnlyCollection<Employee> Employees
            => _employees.AsReadOnly();

        public bool AddEmployee(Employee employee)
        {
            if (Employees.Any(e => e.Id == employee.Id))
                throw new InvalidOperationException($"Employee '{employee.FullName}' is already in team '{Name}'.");

            _employees.Add(employee);

            return true;
        }

        public bool RemoveEmployee(Employee employee)
        {
            if (!Employees.Any(e => e.Id == employee.Id))
                throw new InvalidOperationException($"Employee '{employee.FullName}' is not in team '{Name}'.");

            _employees.Remove(employee);

            return true;
        }
    }
}
