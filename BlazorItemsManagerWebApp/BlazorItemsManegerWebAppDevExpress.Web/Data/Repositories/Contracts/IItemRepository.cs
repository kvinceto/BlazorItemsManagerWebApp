namespace BlazorItemsManegerWebAppDevExpress.Web.Data.Repositories.Contracts
{
    using ViewModels;
    public interface IItemRepository
    {
        Task<bool> CreateItemAsync(ItemAddViewModel itemAddViewModel);

        Task<bool> EditItemAsync(ItemEditViewModel itemEditViewModel);

        Task<ItemInfoViewModel?> GetItemAsync(int id);

        Task<bool> DeleteItemAsync(int id);

        Task<IEnumerable<ItemInfoViewModel>> GetAllItemsAsync();

        Task<IEnumerable<ItemInfoViewModel>> GetAllActiveItemsAsync();

        Task<IEnumerable<ItemInfoViewModel>> GetAllDeletedItemsAsync();
    }
}
