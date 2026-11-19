
using Npgsql;

namespace StudentRecordsManagement.Data
{
    public class DatabaseConnection
    {
        public static NpgsqlConnection GetConnection()
        {
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = "localhost",
                Port = 5432,
                Database = "StudentRecordsDB",
                Username = "postgres",
                Password = Environment.GetEnvironmentVariable(
                    "DB_PASSWORD")
            };

            if (string.IsNullOrWhiteSpace(builder.Password))
            {
                throw new InvalidOperationException(
                    "Student database password is not configured.");
            }

            return new NpgsqlConnection(builder.ConnectionString);
        }

        public static void TestConnection()
        {
            using var connection = GetConnection();
            connection.Open();

            Console.WriteLine("PostgreSQL connection successful!");
            Console.WriteLine("Database: " + connection.Database);
        }
    }
}
