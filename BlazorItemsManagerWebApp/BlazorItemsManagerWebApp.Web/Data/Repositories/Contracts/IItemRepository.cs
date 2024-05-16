using BlazorItemsManagerWebApp.Web.ViewModels;

namespace BlazorItemsManagerWebApp.Web.Data.Repositories.Contracts
{
    public interface IItemRepository
    {
        Task<bool> CreateItemAsync(ItemAddViewModel itemAddViewModel);
    }
}
