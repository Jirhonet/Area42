using A42.Planning.Data.Abstractions;
using A42.Planning.Domain;

namespace A42.Planning.Tests.Mock
{
    public class MockTeamService : ITeamService
    {
        internal List<Team> Teams { get; private set; } = new List<Team>();

        public IEnumerable<Team> Get()
        {
            return Teams;
        }

        public void Add(Team team)
        {
            Teams.Add(team);
        }
    }
}
