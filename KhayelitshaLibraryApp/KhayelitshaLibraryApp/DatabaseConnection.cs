using Microsoft.Data.SqlClient;

namespace KhayelitshaLibraryApp
{
    public static class DatabaseConnection
    {
        private static readonly string connectionString =
            @"Server=.;Database=KhayelitshaLibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}