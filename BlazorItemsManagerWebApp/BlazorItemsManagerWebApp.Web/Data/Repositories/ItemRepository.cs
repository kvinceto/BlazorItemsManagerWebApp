namespace BlazorItemsManagerWebApp.Web.Data.Repositories
{
    using Dapper;

    using Data.Models;
    using Data.Repositories.Contracts;
    using ViewModels;

    using static Common.ApplicationConstants.GlobalContants;

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
                IsDeleted = false,
                Unit = itemAddViewModel.Unit
            };

            string sql = @"INSERT INTO Items (Name, Description, CurrentQuantity, CurrentUnitPrice, CreatedAt, LastModifiedAt, UserId, IsDeleted, Unit)
              VALUES (@Name, @Description, @CurrentQuantity, @CurrentUnitPrice, @CreatedAt, @LastModifiedAt, @UserId, @IsDeleted, @Unit);";

            using (var conection = this.context.CreateConnection())
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
                CurrentQuantity = itemEditViewModel.CurrentQuantity,
                CurrentUnitPrice = itemEditViewModel.CurrentUnitPrice,
                CreatedAt = DateTime.Parse(itemEditViewModel.CreatedAt),
                LastModifiedAt = DateTime.UtcNow,
                UserId = itemEditViewModel.UserId,
                IsDeleted = itemEditViewModel.IsDeleted,
                Unit = itemEditViewModel.Unit
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
                              IsDeleted = @IsDeleted,
                              Unit = @Unit
                           WHERE
                              Id = @Id;";

            using (var conection = this.context.CreateConnection())
            {
                var result = await conection.ExecuteAsync(sql, item);

                return result > 0 ? true : false;
            }
        }

        /// <summary>
        /// The method marks an Item in the databasa as deleted
        /// </summary>
        /// <param name="id">It of the Item</param>
        /// <returns>True or False</returns>
        public async Task<bool> DeleteItemAsync(int id)
        {
            string sql = @"UPDATE Items
                   SET IsDeleted = 1, LastModifiedAt = @LastModifiedAt
                   WHERE Id = @Id AND CurrentQuantity = 0;";

            using (var conection = this.context.CreateConnection())
            {
                var result = await conection.ExecuteAsync(sql, new { LastModifiedAt = DateTime.UtcNow, Id = id });

                return result > 0 ? true : false;
            }
        }

        /// <summary>
        /// This method find all Dealeted Items in the database
        /// </summary>
        /// <returns>Collection of ItemEditViewModel</returns>
        public async Task<IEnumerable<ItemEditViewModel>> GetAllDeletedItemsAsync()
        {
            string sql = @"SELECT Id, Name, Description, CurrentQuantity, CurrentUnitPrice, CreatedAt, LastModifiedAt, UserId, IsDeleted, Unit
                           FROM Items
                           WHERE IsDeleted = 1;";

            using (var conection = this.context.CreateConnection())
            {
                var result = await conection.QueryAsync<Item>(sql);

                return result
                    .Select(item => new ItemEditViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        CurrentQuantity = item.CurrentQuantity,
                        CurrentUnitPrice = item.CurrentUnitPrice,
                        CreatedAt = item.CreatedAt.ToString(DateTimeDefaultFormat),
                        LastModifiedAt = item.LastModifiedAt.ToString(DateTimeDefaultFormat),
                        IsDeleted = item.IsDeleted,
                        UserId = item.UserId,
                        Unit = item.Unit
                    });
            }
        }

        /// <summary>
        /// This method find all Items in the database
        /// </summary>
        /// <returns>Collection of ItemEditViewModel</returns>
        public async Task<IEnumerable<ItemEditViewModel>> GetAllItemsAsync()
        {
            string sql = @"SELECT Id, Name, Description, CurrentQuantity, CurrentUnitPrice, CreatedAt, LastModifiedAt, UserId, IsDeleted, Unit
                           FROM Items;";

            using (var conection = this.context.CreateConnection())
            {
                var result = await conection.QueryAsync<Item>(sql);

                return result
                    .Select(item => new ItemEditViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        CurrentQuantity = item.CurrentQuantity,
                        CurrentUnitPrice = item.CurrentUnitPrice,
                        CreatedAt = item.CreatedAt.ToString(DateTimeDefaultFormat),
                        LastModifiedAt = item.LastModifiedAt.ToString(DateTimeDefaultFormat),
                        IsDeleted = item.IsDeleted,
                        UserId = item.UserId,
                        Unit = item.Unit
                    });
            }
        }

        /// <summary>
        /// This method find all Active Items in the database
        /// </summary>
        /// <returns>Collection of ItemEditViewModel</returns>
        public async Task<IEnumerable<ItemEditViewModel>> GetAllÀctiveItemsAsync()
        {
            string sql = @"SELECT Id, Name, Description, CurrentQuantity, CurrentUnitPrice, CreatedAt, LastModifiedAt, UserId, IsDeleted, Unit
                           FROM Items
                           WHERE IsDeleted = 0;";

            using (var conection = this.context.CreateConnection())
            {
                var result = await conection.QueryAsync<Item>(sql);

                return result
                    .Select(item => new ItemEditViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        CurrentQuantity = item.CurrentQuantity,
                        CurrentUnitPrice = item.CurrentUnitPrice,
                        CreatedAt = item.CreatedAt.ToString(DateTimeDefaultFormat),
                        LastModifiedAt = item.LastModifiedAt.ToString(DateTimeDefaultFormat),
                        IsDeleted = item.IsDeleted,
                        UserId = item.UserId,
                        Unit = item.Unit
                    });
            }
        }

        /// <summary>
        /// This method find an Item in the database
        /// </summary>
        /// <param name="id">Id of the Item</param>
        /// <returns>ItemEditViewModel<returns>
        public async Task<ItemEditViewModel?> GetItemAsync(int id)
        {
            string sql = string.Format(@"SELECT Id, Name, Description, CurrentQuantity, CurrentUnitPrice, CreatedAt, LastModifiedAt, UserId, IsDeleted, Unit
                           FROM Items
                           WHERE Id={0};", id);

            using (var conection = this.context.CreateConnection())
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
                        CreatedAt = result.CreatedAt.ToString(DateTimeDefaultFormat),
                        LastModifiedAt = result.LastModifiedAt.ToString(DateTimeDefaultFormat),
                        UserId = result.UserId,
                        IsDeleted = result.IsDeleted,
                        Unit = result.Unit
                    };
                }
            }
        }
    }
}