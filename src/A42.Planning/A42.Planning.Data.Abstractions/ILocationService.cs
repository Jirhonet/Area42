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
        /// Adds a new location.
        /// </summary>
        /// <param name="location">Location to add.</param>
        public void Add(Location location);

        /// <summary>
        /// Removes an existing location.
        /// </summary>
        /// <param name="location">Location to remove.</param>
        public void Remove(Location location);
    }
}
