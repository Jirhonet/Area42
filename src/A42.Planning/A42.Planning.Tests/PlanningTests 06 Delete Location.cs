using A42.Planning.Domain;
using FluentAssertions;

namespace A42.Planning.Tests
{
    public partial class PlanningTests
    {
        [TestMethod("P 06: Delete location not used in planning")]
        public void P_06_DeleteLocation_NotUsedInPlanning()
        {
            // Arrange
            Location location = new Location(1, "Location to Delete");
            _locationService.Add(location);

            // Act
            _locationService.Remove(location);

            // Assert
            var locations = _locationService.Get();
            locations.Should().NotContain(l => l.Id == location.Id);
        }
    }
}