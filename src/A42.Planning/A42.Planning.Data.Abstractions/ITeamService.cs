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
        /// Adds a new team.
        /// </summary>
        /// <param name="team">Team to add.</param>
        public void Add(Team team);
    }
}
