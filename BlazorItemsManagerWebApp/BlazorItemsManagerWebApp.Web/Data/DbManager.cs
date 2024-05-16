using Dapper;

using Microsoft.Data.SqlClient;

namespace BlazorItemsManagerWebApp.Web.Data
{
    public class DbManager
    {
        private string connectionString;

        public DbManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InitializeDatabase()
        {
            using (var conection = new SqlConnection(this.connectionString))
            {
                conection.Open();

                conection.Execute(@"CREATE TABLE Item2 (
                                                id INT PRIMARY KEY IDENTITY,
                                                name NVARCHAR(100),
                                                quantity INT
                                        );");
            }
        }
    }
}
