using A42.Planning.Domain;

namespace A42.Planning.Data.Abstractions
{
    public interface ITeamService
    {
        /// <summary>
        /// Gets all teams.
        /// </summary>
        /// <returns>All teams.</returns>
        public IEnumerable<Team> Get();

        /// <summary>
        /// Gets a single team by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Team with the given id.</returns>
        public Team GetById(int id);

        /// <summary>
        /// Adds a new team.
        /// </summary>
        /// <param name="team">Team to add.</param>
        public void Add(Team team);

        /// <summary>
        /// Removes an existing team.
        /// </summary>
        /// <param name="teamId">Team to remove.</param>
        public void Remove(int teamId);
    }
}
