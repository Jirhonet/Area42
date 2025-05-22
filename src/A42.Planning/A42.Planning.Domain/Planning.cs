namespace A42.Planning.Domain
{
    public class Planning
    {
        private List<PlanningItem> _items = [];

        public Planning(DateOnly date)
        {
            Date = date;
        }

        public DateOnly Date { get; private init; }

        public IReadOnlyList<PlanningItem> Items
            => _items;
    }
}
