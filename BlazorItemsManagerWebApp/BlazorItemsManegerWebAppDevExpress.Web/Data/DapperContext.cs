namespace BlazorItemsManegerWebAppDevExpress.Web.Data
{
    using Microsoft.Data.SqlClient;

    using System.Data;

    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = this.configuration.GetConnectionString("DefaultConnection")!;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(connectionString);
    }
}
