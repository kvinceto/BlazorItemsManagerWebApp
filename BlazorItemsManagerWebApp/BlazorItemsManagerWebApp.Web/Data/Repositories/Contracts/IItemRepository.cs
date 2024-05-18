using BlazorItemsManagerWebApp.Web.ViewModels;

namespace BlazorItemsManagerWebApp.Web.Data.Repositories.Contracts
{
    public interface IItemRepository
    {
        Task<bool> CreateItemAsync(ItemAddViewModel itemAddViewModel);

        Task<bool> EditItemAsync(ItemEditViewModel itemEditViewModel);

        Task<ItemInfoViewModel?> GetItemAsync(int id);

        Task<bool> DeleteItemAsync(int id);

        Task<IEnumerable<ItemInfoViewModel>> GetAllItemsAsync();

        Task<IEnumerable<ItemInfoViewModel>> GetAllÀctiveItemsAsync();

        Task<IEnumerable<ItemInfoViewModel>> GetAllDeletedItemsAsync();
    }
}
