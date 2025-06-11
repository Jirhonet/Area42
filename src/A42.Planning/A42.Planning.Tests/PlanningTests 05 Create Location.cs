using A42.Planning.Domain;
using A42.Planning.Tests.Mock;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace A42.Planning.Tests
{
    public partial class PlanningTests
    {
        [TestMethod("P 05a: Create location with valid name")]
        public void P_05a_CreateLocation_WithValidName()
        {
            // Arrange
            string locationName = "New Location";

            // Act
            Location location = new Location(1, locationName);
            _locationService.Add(location);

            // Assert
            var locations = _locationService.Get();
            locations.Should().Contain(l => l.Name == locationName);
        }

        [TestMethod("P 05b: Create location with existing name")]
        public void P_05b_CreateLocation_WithExistingName()
        {
            // Arrange
            string locationName = "Existing Location";
            Location existingLocation = new Location(1, locationName);
            _locationService.Add(existingLocation);

            // Act
            Action action = () => _locationService.Add(new Location(2, locationName));

            // Assert
            action.Should().Throw<InvalidOperationException>()
                .WithMessage($"A location with name '{locationName}' already exists.");
        }
    }
} 