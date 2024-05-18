using Microsoft.Data.SqlClient;
using System.Data;

namespace BlazorItemsManagerWebApp.Web.Data
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("DefaultConnection")!;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(this.connectionString);
    }
}
