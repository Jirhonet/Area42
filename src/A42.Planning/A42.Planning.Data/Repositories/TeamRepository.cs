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
    }
}
