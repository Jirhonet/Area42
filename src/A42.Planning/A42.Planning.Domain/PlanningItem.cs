namespace A42.Planning.Domain
{
    public class PlanningItem
    {
        public PlanningItem(
            int id,
            string title,
            Location location,
            TimeOnly start,
            TimeOnly end
        )
        {
            Id = id;
            Title = title;
            Location = location;
            Start = start;
            End = end;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public Location Location { get; private set; }
        public TimeOnly Start { get; private set; }
        public TimeOnly End { get; private set; }
    }
}
