using A42.Planning.Data.Dtos;

namespace A42.Planning.Data.Repositories
{
    public class PlanningItemRepository : RepositoryBase
    {
        private readonly LocationRepository _locationRepository;

        public PlanningItemRepository(DataContext dataContext, LocationRepository locationRepository)
            : base(dataContext)
        {
            _locationRepository = locationRepository;
        }

        public IEnumerable<PlanningItemDto> Get(DateTime date, int teamId)
        {
            const string sql = """
                SELECT
                    p.Id,
                    p.Title,
                    p.ParkLocationId AS LocationId,
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
                INSERT INTO PlanningItem (Title, ParkLocationId, TeamId, Start, End)
                VALUES (@Title, @LocationId, @TeamId, @Start, @End)
                """;

            var param = new
            {
                Title = planningItem.Title,
                LocationId = planningItem.LocationId,
                TeamId = planningItem.TeamId,
                Start = planningItem.Start,
                End = planningItem.End,
            };

            return Execute(sql, param);
        }

        public int Delete(int id)
        {
            const string sql = """
                DELETE FROM PlanningItem
                WHERE Id = @Id
                """;

            var param = new
            {
                Id = id,
            };

            return Execute(sql, param);
        }
    }
}
