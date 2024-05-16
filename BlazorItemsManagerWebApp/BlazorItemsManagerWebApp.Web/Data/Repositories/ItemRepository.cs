using Dapper;
using Microsoft.Data.SqlClient;

using BlazorItemsManagerWebApp.Web.Data.Models;
using BlazorItemsManagerWebApp.Web.Data.Repositories.Contracts;
using BlazorItemsManagerWebApp.Web.ViewModels;

namespace BlazorItemsManagerWebApp.Web.Data.Repositories
{

    public class ItemRepository : IItemRepository
    {
        private readonly IConfiguration configuration;

        public ItemRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<bool> CreateItemAsync(ItemAddViewModel itemAddViewModel)
        {
            var date = DateTime.UtcNow;
            Item item = new Item()
            {
                Name = itemAddViewModel.Name,
                Description = itemAddViewModel.Description,
                CurrentQuantity = itemAddViewModel.CurrentQuantity,
                CurrentUnitPrice = itemAddViewModel.CurrentUnitPrice,
                CreatedAt = date,
                LastModifiedAt = date,
                UserId = itemAddViewModel.UserId
            };

            string sql = @"INSERT INTO Items (Name, Description, CurrentQuantity, CurrentUnitPrice, CreatedAt, LastModifiedAt, UserId)
              VALUES (@Name, @Description, @CurrentQuantity, @CurrentUnitPrice, @CreatedAt, @LastModifiedAt, @UserId);";

            using (var conection = GetConection())
            {
                var result = await conection.ExecuteAsync(sql, item);

                return result > 0 ? true : false;
            }    
        }



        /// <summary>
        /// This method ccreates a connection to the database
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection GetConection()
        {
            return new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}