using System.Data;
using MySql.Data.MySqlClient;

namespace A42.Planning.Data.Repositories
{
    public class DataContext : IDisposable
    {
        private readonly string _connectionString;

        private MySqlConnection? _connection;

        public DataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new MySqlConnection(_connectionString);
                _connection.Open();
            }

            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
