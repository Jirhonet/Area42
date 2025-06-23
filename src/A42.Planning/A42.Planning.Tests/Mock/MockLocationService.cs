using A42.Planning.Data.Abstractions;
using A42.Planning.Domain;

namespace A42.Planning.Tests.Mock
{
    public class MockLocationService : ILocationService
    {
        internal List<Location> Locations { get; private set; } = new List<Location>();

        public IEnumerable<Location> Get()
        {
            return Locations;
        }

        public void Add(Location location)
        {
            if (Locations.Any(l => l.Name == location.Name))
                throw new InvalidOperationException($"A location with name '{location.Name}' already exists.");

            Locations.Add(location);
        }

        public void Remove(Location location)
        {
            Locations.Remove(location);
        }

        public Location GetById(int locationId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int locationId)
        {
            throw new NotImplementedException();
        }
    }
}
