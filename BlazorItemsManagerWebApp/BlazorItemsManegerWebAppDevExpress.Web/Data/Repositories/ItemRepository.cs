namespace BlazorItemsManegerWebAppDevExpress.Web.Data.Repositories
{
    using Dapper;

    using Data;
    using Data.Models;
    using Data.Repositories.Contracts;

    using ViewModels;

    using static Common.ApplicationConstants.ItemConstants;

    public class ItemRepository : IItemRepository
    {
        private readonly IDapperContext context;

        public ItemRepository(IDapperContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This method creates an Item in the database
        /// </summary>
        /// <param name="itemAddViewModel">Item data</param>
        /// <returns>True or False</returns>
        public async Task<bool> CreateItemAsync(ItemAddViewModel itemAddViewModel)
        {
            var date = DateTime.UtcNow.ToString(DateTimeDefaultFormat);
            Item item = new Item()
            {
                Name = itemAddViewModel.Name,
                Description = itemAddViewModel.Description,
                Price = itemAddViewModel.Price,
                CreatedAd = date,
                IsDeleted = false
            };

            string sql = @"INSERT INTO Items (Name, Description, Price, CreatedAd, IsDeleted)
              VALUES (@Name, @Description, @Price, @CreatedAd, @IsDeleted);";

            using (var conection = context.CreateConnection())
            {
                var result = await conection.ExecuteAsync(sql, item);

                return result > 0 ? true : false;
            }
        }

        /// <summary>
        /// This method modifies an Item in the database
        /// </summary>
        /// <param name="itemEditViewModel">Item data</param>
        /// <returns>True or False</returns>
        public async Task<bool> EditItemAsync(ItemEditViewModel itemEditViewModel)
        {
            Item item = new Item()
            {
                Id = itemEditViewModel.Id,
                Name = itemEditViewModel.Name,
                Description = itemEditViewModel.Description,
                Price = itemEditViewModel.Price
            };

            string sql = @"UPDATE Items
                           SET
                              Name = @Name,
                              Description = @Description,      
                              Price = @Price
                           WHERE
                              Id = @Id;";

            using (var conection = context.CreateConnection())
            {
                var result = await conection.ExecuteAsync(sql, item);

                return result > 0 ? true : false;
            }
        }

        /// <summary>
        /// The method marks an Item in the databasa as deleted
        /// </summary>
        /// <param name="id">Id of the Item</param>
        /// <returns>True or False</returns>
        public async Task<bool> DeleteItemAsync(int id)
        {
            string sql = @"UPDATE Items
                   SET IsDeleted = 1
                   WHERE Id = @Id;";

            using (var conection = context.CreateConnection())
            {
                var result = await conection.ExecuteAsync(sql, new { Id = id });

                return result > 0 ? true : false;
            }
        }

        /// <summary>
        /// This method find all Deleated Items in the database
        /// </summary>
        /// <returns>Collection of ItemInfoViewModel</returns>
        public async Task<IEnumerable<ItemInfoViewModel>> GetAllDeletedItemsAsync()
        {
            string sql = @"SELECT Id, Name, Description, Price, CreatedAd
                           FROM Items
                           WHERE IsDeleted = 1;";

            using (var conection = context.CreateConnection())
            {
                var result = await conection.QueryAsync<Item>(sql);

                return result
                    .Select(item => new ItemInfoViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Price = item.Price,
                        CreatedAd = item.CreatedAd
                    });
            }
        }

        /// <summary>
        /// This method find all Items in the database
        /// </summary>
        /// <returns>Collection of ItemInfoViewModel</returns>
        public async Task<IEnumerable<ItemInfoViewModel>> GetAllItemsAsync()
        {
            string sql = @"SELECT Id, Name, Description, Price, CreatedAd
                           FROM Items";

            using (var conection = context.CreateConnection())
            {
                var result = await conection.QueryAsync<Item>(sql);

                return result
                    .Select(item => new ItemInfoViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Price = item.Price,
                        CreatedAd = item.CreatedAd
                    });
            }
        }

        /// <summary>
        /// This method find all Active Items in the database
        /// </summary>
        /// <returns>Collection of ItemInfoViewModel</returns>
        public async Task<IEnumerable<ItemInfoViewModel>> GetAllActiveItemsAsync()
        {
            string sql = @"SELECT Id, Name, Description, Price, CreatedAd
                           FROM Items
                           WHERE IsDeleted = 0;";

            using (var conection = context.CreateConnection())
            {
                var result = await conection.QueryAsync<Item>(sql);

                var r = result
                    .Select(item => new ItemInfoViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Price = item.Price,
                        CreatedAd = item.CreatedAd
                    });

                return r;
            }
        }

        /// <summary>
        /// This method find an Item in the database
        /// </summary>
        /// <param name="id">Id of the Item</param>
        /// <returns>ItemInfoViewModel or Null<returns>
        public async Task<ItemInfoViewModel?> GetItemAsync(int id)
        {
            string sql = @"SELECT Id, Name, Description, Price, CreatedAd
                           FROM Items
                           WHERE Id=@Id;";

            using (var conection = context.CreateConnection())
            {
                var result = await conection.QueryFirstOrDefaultAsync<Item>(sql, new { Id = id });

                if (result == null)
                {
                    return null;
                }
                else
                {
                    return new ItemInfoViewModel()
                    {
                        Id = result.Id,
                        Name = result.Name,
                        Description = result.Description,
                        Price = result.Price,
                        CreatedAd = result.CreatedAd
                    };
                }
            }
        }
    }
}