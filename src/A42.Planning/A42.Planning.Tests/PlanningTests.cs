#pragma warning disable CS8618

using A42.Planning.Tests.Mock;
using Microsoft.Extensions.DependencyInjection;

namespace A42.Planning.Tests
{
    [TestClass]
    public partial class PlanningTests
    {
        private readonly ServiceProvider _services;
        private MockPlanningService _planningService;
        private MockTeamService _teamService;
        private MockLocationService _locationService;

        public PlanningTests()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<MockPlanningService>();
            services.AddScoped<MockTeamService>();
            services.AddScoped<MockLocationService>();
            _services = services.BuildServiceProvider();
        }

        [TestInitialize]
        public void Initialize()
        {
            _planningService = _services.GetRequiredService<MockPlanningService>();
            _teamService = _services.GetRequiredService<MockTeamService>();
            _locationService = _services.GetRequiredService<MockLocationService>();
        }
    }
}
