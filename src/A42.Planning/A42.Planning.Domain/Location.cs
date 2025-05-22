namespace A42.Planning.Domain
{
    public class Location
    {
        public Location(string name)
        {
            Name = name;
        }

        public string Name { get; private init; }
    }
}
