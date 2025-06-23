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
            if (Teams.Any(t => t.Name == team.Name))
                throw new InvalidOperationException($"A team with name '{team.Name}' already exists.");

            Teams.Add(team);
        }

        public void Remove(Team team)
        {
            Teams.Remove(team);
        }

        public Team GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int teamId)
        {
            throw new NotImplementedException();
        }
    }
}
