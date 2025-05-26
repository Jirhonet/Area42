namespace A42.Planning.Domain.Abstractions.Interfaces
{
    public interface ILocationService
    {
        public IEnumerable<Location> Get();

        public void Add(Location location);
    }
}
