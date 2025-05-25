using A42.Planning.Data.Dtos;

namespace A42.Planning.Data.Repositories
{
    public class PlanningItemRepository : RepositoryBase
    {
        public PlanningItemRepository(DataContext dataContext)
            : base(dataContext)
        {
            //
        }

        public IEnumerable<PlanningItemDto> Get(DateOnly date, int teamId)
        {
            const string sql = """
                SELECT
                    p.Id,
                    p.LocationId,
                    p.TeamId,
                    p.Start,
                    p.End
                FROM PlanningItem p
                WHERE
                    p.TeamId = @TeamId
                    AND CAST(p.Start AS DATE) = @Date
                    AND CAST(p.End AS DATE) = @Date
                """;

            var param = new
            {
                Date = date,
                TeamId = teamId,
            };

            return Query<PlanningItemDto>(sql, param);
        }

        public int Insert(PlanningItemDto planningItem)
        {
            const string sql = """
                INSERT INTO PlanningItem (LocationId, TeamId, Start, End)
                VALUES (@LocationId, @TeamId, @Start, @End)
                """;

            var param = new
            {
                LocationId = planningItem.LocationId,
                TeamId = planningItem.TeamId,
                Start = planningItem.Start,
                End = planningItem.End,
            };

            return Execute(sql, param);
        }
    }
}
