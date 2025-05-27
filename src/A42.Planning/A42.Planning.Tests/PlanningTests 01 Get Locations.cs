using A42.Planning.Domain;
using FluentAssertions;

namespace A42.Planning.Tests
{
    public partial class PlanningTests
    {
        [TestMethod("PT 01: Get locations")]
        public void PT_01_Get_Locations()
        {
            // Arrange
            Location location1 = new Location(1, "Location 1");
            _locationService.Locations.Add(location1);
            Location location2 = new Location(2, "Location 2");
            _locationService.Locations.Add(location2);
            Location location3 = new Location(3, "Location 3");
            _locationService.Locations.Add(location3);

            // Act
            IEnumerable<Location> locations = _locationService.Get();

            // Assert
            locations.Should().NotBeNullOrEmpty();
            locations.Should().HaveCount(3);
        }
    }
}
