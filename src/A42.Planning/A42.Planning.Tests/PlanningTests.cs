#pragma warning disable CS8618

using A42.Planning.Tests.Mock;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace A42.Planning.Tests
{
    [TestClass]
    public partial class PlanningTests
    {
        private readonly ServiceProvider _services;

        private MockLocationService _locationService;
        private MockPlanningService _planningService;
        private MockTeamService _teamService;


        public PlanningTests()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddScoped<MockLocationService>();
            services.AddScoped<MockPlanningService>();
            services.AddScoped<MockTeamService>();

            _services = services.BuildServiceProvider();
        }

        [TestInitialize]
        public void Initialize()
        {
            _locationService = _services.GetRequiredService<MockLocationService>();
            _planningService = _services.GetRequiredService<MockPlanningService>();
            _teamService = _services.GetRequiredService<MockTeamService>();
        }

        [TestMethod("PT 00: General")]
        public void PT_00_General()
        {
            _locationService.Should().NotBeNull();
            _planningService.Should().NotBeNull();
            _teamService.Should().NotBeNull();
        }
    }
}
