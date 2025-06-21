namespace A42.Planning.Data.Dtos
{
    public class PlanningItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int LocationId { get; set; }
        public int TeamId { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
    }
}
