using Menus.Domain.Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menus.Domain.Menu.Repositories
{
    public interface IMenuReadRepository
    {
        #region
        Task<List<MenuItem>> FetchAllMenuEntityAsync();
        Task<MenuItem> FetchMenuEntityAsync(int id);
        Task<List<MenuCategory>> FetchAllMenuCategoryAsync();
        Task<MenuCategory> FetchMenuCategoryAsync(int id);
        #endregion


    }
}
