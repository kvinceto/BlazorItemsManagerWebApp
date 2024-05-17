using BlazorItemsManagerWebApp.Web.ViewModels;

namespace BlazorItemsManagerWebApp.Web.Data.Repositories.Contracts
{
    public interface IItemRepository
    {
        Task<bool> CreateItemAsync(ItemAddViewModel itemAddViewModel);

        Task<bool> EditItemAsync(ItemEditViewModel itemEditViewModel);

        Task<ItemEditViewModel?> GetItemAsync(int id);

        Task<bool> DeleteItemAsync(int id);

        Task<IEnumerable<ItemEditViewModel>> GetAllItemsAsync();

        Task<IEnumerable<ItemEditViewModel>> GetAllÀctiveItemsAsync();

        Task<IEnumerable<ItemEditViewModel>> GetAllDeletedItemsAsync();
    }
}
