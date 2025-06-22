using A42.Planning.Domain;

namespace A42.Planning.Data.Abstractions
{
    public interface ILocationService
    {
        /// <summary>
        /// Gets all locations.
        /// </summary>
        /// <returns>All locations.</returns>
        public IEnumerable<Location> Get();

        /// <summary>
        /// Gets a single location by its id.
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns>The location with the given id.</returns>
        public Location GetById(int locationId);

        /// <summary>
        /// Adds a new location.
        /// </summary>
        /// <param name="location">Location to add.</param>
        public void Add(Location location);

        /// <summary>
        /// Removes an existing location.
        /// </summary>
        /// <param name="locationId">Location to remove.</param>
        public void Remove(int locationId);
    }
}
