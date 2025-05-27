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

            locations.Should().Contain(location1);
            location1.Should().NotBeNull();
            location1.Id.Should().Be(1);
            location1.Name.Should().Be("Location 1");

            locations.Should().Contain(location2);
            location2.Should().NotBeNull();
            location2.Id.Should().Be(2);
            location2.Name.Should().Be("Location 2");

            locations.Should().Contain(location3);
            location3.Should().NotBeNull();
            location3.Id.Should().Be(3);
            location3.Name.Should().Be("Location 3");
        }
    }
}
