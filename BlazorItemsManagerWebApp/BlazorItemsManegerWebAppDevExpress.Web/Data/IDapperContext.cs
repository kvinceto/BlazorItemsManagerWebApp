namespace BlazorItemsManegerWebAppDevExpress.Web.Data
{
    using System.Data;
    public interface IDapperContext
    {
        public IDbConnection CreateConnection();
    }
}
