using A42.Planning.Data.Dtos;

namespace A42.Planning.Data.Repositories
{
    public class TeamRepository : RepositoryBase
    {
        public TeamRepository(DataContext dataContext)
            : base(dataContext)
        {
            //
        }

        public IEnumerable<TeamDto> Get()
        {
            const string sql = """
                SELECT
                    t.Id,
                    t.Name
                FROM Team t
                """;

            return Query<TeamDto>(sql);
        }

        public int Insert(TeamDto team)
        {
            const string sql = """
                INSERT INTO Team (Name)
                VALUES (@Name)
                """;

            var param = new
            {
                Name = team.Name,
            };

            return Execute(sql, param);
        }

        public int Delete(int id)
        {
            const string sql = """
                DELETE FROM Team
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
