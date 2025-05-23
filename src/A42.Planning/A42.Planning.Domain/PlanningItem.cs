namespace A42.Planning.Domain
{
    public class PlanningItem
    {
        public PlanningItem(
            string title,
            Location location,
            DateTimeOffset start,
            DateTimeOffset end
        )
        {
            Title = title;
            Location = location;
            Start = start;
            End = end;
        }

        public string Title { get; private set; }
        public Location Location { get; private set; }
        public DateTimeOffset Start { get; private set; }
        public DateTimeOffset End { get; private set; }
    }
}
