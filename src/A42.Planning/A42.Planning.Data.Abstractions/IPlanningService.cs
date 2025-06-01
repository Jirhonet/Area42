using A42.Planning.Domain;

namespace A42.Planning.Data.Abstractions
{
    public interface IPlanningService
    {
        /// <summary>
        /// Gets the planning for a specific date and team.
        /// </summary>
        /// <param name="date">Date for which to get the planning.</param>
        /// <param name="team">Team for which to get the planning.</param>
        /// <returns>The planning.</returns>
        public Domain.Planning Get(DateOnly date, Team team);

        /// <summary>
        /// Adds a new planning item to the planning.
        /// </summary>
        /// <param name="planning">Planning to add the item to.</param>
        /// <param name="planningItem">Planning item to add.</param>
        public void Add(Domain.Planning planning, PlanningItem planningItem);

        /// <summary>
        /// Removes an existing planning item.
        /// </summary>
        /// <param name="planningItem">Planning item to remove.</param>
        public void Remove(PlanningItem planningItem);
    }
}
