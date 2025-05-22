using Dapper;
using MySql.Data.MySqlClient;

namespace A42.Planning.Data.Repositories
{
    public class RepositoryBase
    {
        public RepositoryBase(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        protected DataContext DataContext { get; private init; }

        protected IEnumerable<TResult> Query<TResult>(string sql)
        {
            return Query<TResult>(sql, null);
        }

        protected IEnumerable<TResult> Query<TResult>(string sql, object? param)
        {
            using MySqlConnection connection = DataContext.GetConnection();

            return connection.Query<TResult>(sql, param);
        }

        protected TResult QuerySingle<TResult>(string sql)
        {
            return QuerySingle<TResult>(sql, null);
        }

        protected TResult QuerySingle<TResult>(string sql, object? param)
        {
            using MySqlConnection connection = DataContext.GetConnection();

            return connection.QuerySingle<TResult>(sql, param);
        }

        protected TResult? QuerySingleOrDefault<TResult>(string sql)
        {
            return QuerySingleOrDefault<TResult>(sql, null);
        }

        protected TResult? QuerySingleOrDefault<TResult>(string sql, object? param)
        {
            using MySqlConnection connection = DataContext.GetConnection();

            return connection.QuerySingleOrDefault<TResult>(sql, param);
        }

        protected TResult QueryFirst<TResult>(string sql)
        {
            return QueryFirst<TResult>(sql, null);
        }

        protected TResult QueryFirst<TResult>(string sql, object? param)
        {
            using MySqlConnection connection = DataContext.GetConnection();

            return connection.QueryFirst<TResult>(sql, param);
        }

        protected TResult? QueryFirstOrDefault<TResult>(string sql)
        {
            return QueryFirstOrDefault<TResult>(sql, null);
        }

        protected TResult? QueryFirstOrDefault<TResult>(string sql, object? param)
        {
            using MySqlConnection connection = DataContext.GetConnection();

            return connection.QueryFirstOrDefault<TResult>(sql, param);
        }

        protected TResult? ExecuteScalar<TResult>(string sql)
        {
            return ExecuteScalar<TResult>(sql, null);
        }

        protected TResult? ExecuteScalar<TResult>(string sql, object? param)
        {
            using MySqlConnection connection = DataContext.GetConnection();

            return connection.ExecuteScalar<TResult>(sql, param);
        }

        protected int Execute(string sql)
        {
            return Execute(sql, null);
        }

        protected int Execute(string sql, object? param)
        {
            using MySqlConnection connection = DataContext.GetConnection();

            return connection.Execute(sql, param);
        }
    }
}
