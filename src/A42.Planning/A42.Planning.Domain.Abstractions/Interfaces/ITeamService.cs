namespace A42.Planning.Domain.Abstractions.Interfaces
{
    public interface ITeamService
    {
        public IEnumerable<Team> Get();

        public void Add(Team team);
    }
}
