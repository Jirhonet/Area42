using A42.Planning.Data.Abstractions;
using A42.Planning.Domain;

namespace A42.Planning.Tests.Mock
{
    public partial class MockLocationService : ILocationService
    {
        internal List<Location> Locations { get; private set; } = new List<Location>();

        public IEnumerable<Location> Get()
        {
            return Locations;
        }

        public void Add(Location location)
        {
            Locations.Add(location);
        }
    }
}
