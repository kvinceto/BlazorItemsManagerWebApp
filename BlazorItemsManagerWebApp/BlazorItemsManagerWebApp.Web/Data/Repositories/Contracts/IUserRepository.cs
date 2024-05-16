using BlazorItemsManagerWebApp.Web.ViewModels;

namespace BlazorItemsManagerWebApp.Web.Data.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<UserViewModel?> GetUserByEmailAsync(string email);

        Task<int> RegisterUserAsync(UserViewModel user);
    }
}
