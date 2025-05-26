namespace A42.Planning.Domain
{
    public class Planning
    {
        private List<PlanningItem> _items = [];

        public Planning(DateOnly date, Team team, IEnumerable<PlanningItem> items)
        {
            if (!items.All(ValidateItem))
                throw new InvalidOperationException("Invalid items in planning.");

            Date = date;
            Team = team;
        }

        public DateOnly Date { get; private init; }
        public Team Team { get; private init; }

        public IReadOnlyList<PlanningItem> Items
            => _items;

        public bool AddItem(PlanningItem item)
        {
            _items.Add(item);

            return true;
        }

        private bool ValidateItem(PlanningItem item)
        {
            if (_items.Any(i => i.Start == item.Start && i.End == item.End))
                throw new InvalidOperationException("Item already exists in planning.");

            if (_items.Any(i => i.Start < item.End && i.End > item.Start))
                throw new InvalidOperationException("Item overlaps with existing items.");

            return true;
        }
    }
}
