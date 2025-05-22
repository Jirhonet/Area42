namespace A42.Planning.Domain
{
    public class Employee
    {
        public Employee(int id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }

        public int Id { get; private init; }
        public string FullName { get; private init; }
    }
}
