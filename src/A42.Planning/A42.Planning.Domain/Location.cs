namespace A42.Planning.Domain
{
    public class Location
    {
        public Location(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private init; }
    }
}
