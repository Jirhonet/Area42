using System.Collections.ObjectModel;
using System.Text;

namespace A42.Planning.Domain
{
    public class Planning
    {
        private List<PlanningItem> _items = [];

        public Planning(DateOnly date, Team team, IEnumerable<PlanningItem> items)
        {
            foreach (PlanningItem item in items)
                AddItem(item);

            Date = date;
            Team = team;
        }

        public DateOnly Date { get; private init; }
        public Team Team { get; private init; }

        public ReadOnlyCollection<PlanningItem> Items
            => _items.AsReadOnly();

        public bool AddItem(PlanningItem item)
        {
            if (!ValidateItem(item))
                return false;

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

        public bool RemoveItem(PlanningItem item)
        {
            return _items.Remove(item);
        }

        public string Display()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planning for {Date.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Team: {Team.Name}");

            foreach (PlanningItem item in Items)
            {
                sb.AppendLine($"{item.Start.ToString("HH:mm")} - {item.End.ToString("HH:mm")} {item.Title}");
            }

            return sb.ToString();
        }
    }
}
