﻿using A42.Planning.Data.Dtos;

namespace A42.Planning.Data.Repositories
{
    public class LocationRepository : RepositoryBase
    {
        public LocationRepository(DataContext dataContext)
            : base(dataContext)
        {
            //
        }

        public IEnumerable<LocationDto> Get()
        {
            const string sql = """
                SELECT
                    l.Id,
                    l.Name
                FROM ParkLocation l
                """;

            return Query<LocationDto>(sql);
        }

        public int Insert(LocationDto location)
        {
            const string sql = """
                INSERT INTO ParkLocation (Name)
                VALUES (@Name)
                """;

            var param = new
            {
                Name = location.Name,
            };

            return Execute(sql, param);
        }
    }
}
