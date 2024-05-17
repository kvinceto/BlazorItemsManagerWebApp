using Dapper;
using Microsoft.Data.SqlClient;

using BlazorItemsManagerWebApp.Web.Data.Models;
using BlazorItemsManagerWebApp.Web.Data.Repositories.Contracts;
using BlazorItemsManagerWebApp.Web.ViewModels;
using BlazorItemsManagerWebApp.Web.Pages;

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
                UserId = itemAddViewModel.UserId,
                IsDeleted = false
            };

            string sql = @"INSERT INTO Items (Name, Description, CurrentQuantity, CurrentUnitPrice, CreatedAt, LastModifiedAt, UserId, IsDeleted)
              VALUES (@Name, @Description, @CurrentQuantity, @CurrentUnitPrice, @CreatedAt, @LastModifiedAt, @UserId, @IsDeleted);";

            using (var conection = GetConection())
            {
                var result = await conection.ExecuteAsync(sql, item);

                return result > 0 ? true : false;
            }
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var date = DateTime.UtcNow;
            string sql = string.Format(@"UPDATE Items
                           SET IsDeleted = 1, LastModifiedAt = {0}
                           WHERE Id = {1};", date, id);

            using (var conection = GetConection())
            {
                var result = await conection.ExecuteAsync(sql);

                return result > 0 ? true : false;
            }
        }

        public async Task<bool> EditItemAsync(ItemEditViewModel itemEditViewModel)
        {
            Item item = new Item()
            {
                Id = itemEditViewModel.Id,
                Name = itemEditViewModel.Name,
                Description = itemEditViewModel.Description,
                CurrentQuantity = itemEditViewModel.CurrentQuantity,
                CurrentUnitPrice = itemEditViewModel.CurrentUnitPrice,
                CreatedAt = itemEditViewModel.CreatedAt,
                LastModifiedAt = DateTime.UtcNow,
                UserId = itemEditViewModel.UserId,
                IsDeleted = itemEditViewModel.IsDeleted
            };

            string sql = @"UPDATE Items
                           SET
                              Name = @Name,
                              Description = @Description,
                              CurrentQuantity = @CurrentQuantity,
                              CurrentUnitPrice = @CurrentUnitPrice,
                              CreatedAt = @CreatedAt,
                              LastModifiedAt = @LastModifiedAt,
                              UserId = @UserId,
                              IsDeleted = @IsDeleted
                           WHERE
                              Id = @Id;";

            using (var conection = GetConection())
            {
                var result = await conection.ExecuteAsync(sql, item);

                return result > 0 ? true : false;
            }
        }

        public async Task<IEnumerable<ItemEditViewModel>> GetAllDeletedItemsAsync()
        {
            string sql = @"SELECT Id, Name, Description, CurrentQuantity, CurrentUnitPrice, CreatedAt, LastModifiedAt, UserId, IsDeleted
                           FROM Items
                           WHERE IsDeleted = 1;";

            using (var conection = GetConection())
            {
                var result = await conection.QueryAsync<ItemEditViewModel>(sql);

                return result;
            }
        }

        public async Task<IEnumerable<ItemEditViewModel>> GetAllItemsAsync()
        {
            string sql = @"SELECT Id, Name, Description, CurrentQuantity, CurrentUnitPrice, CreatedAt, LastModifiedAt, UserId, IsDeleted
                           FROM Items;";

            using (var conection = GetConection())
            {
                var result = await conection.QueryAsync<ItemEditViewModel>(sql);

                return result;
            }
        }

        public async Task<IEnumerable<ItemEditViewModel>> GetAllÀctiveItemsAsync()
        {
            string sql = @"SELECT Id, Name, Description, CurrentQuantity, CurrentUnitPrice, CreatedAt, LastModifiedAt, UserId, IsDeleted
                           FROM Items
                           WHERE IsDeleted = 0;";

            using (var conection = GetConection())
            {
                var result = await conection.QueryAsync<ItemEditViewModel>(sql);

                return result;
            }
        }

        public async Task<ItemEditViewModel?> GetItemAsync(int id)
        {
            string sql = string.Format(@"SELECT Id, Name, Description, CurrentQuantity, CurrentUnitPrice, CreatedAt, LastModifiedAt, UserId, IsDeleted
                           FROM Items
                           WHERE Id={0};", id);

            using (var conection = GetConection())
            {
                var result = await conection.QueryFirstOrDefaultAsync<Item>(sql);

                if (result == null)
                {
                    return null;
                }
                else
                {
                    return new ItemEditViewModel()
                    {
                        Id = result.Id,
                        Name = result.Name,
                        Description = result.Description,
                        CurrentQuantity = result.CurrentQuantity,
                        CurrentUnitPrice = result.CurrentUnitPrice,
                        CreatedAt = result.CreatedAt,
                        LastModifiedAt = result.LastModifiedAt,
                        UserId = result.UserId,
                        IsDeleted = result.IsDeleted
                    };
                }
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