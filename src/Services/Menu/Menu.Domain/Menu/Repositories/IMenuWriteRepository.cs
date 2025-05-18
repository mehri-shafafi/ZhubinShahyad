using Menus.Domain.Menu.Models;

namespace Menus.Domain.Menu.Repositories
{
    public interface IMenuWriteRepository
    {
        #region 
        Task<MenuItem> AddMenuItemAsync(MenuItem menuItem);
        Task<MenuItem> UpdateMenuItemAsync(MenuItem menuItem);
        Task DeleteMenuItemAsync(MenuItem menuItem);
        Task<MenuCategory> AddMenuCategoriesAsync(MenuCategory menuCategory);
        Task<MenuCategory> UpdateMenuCategoriesAsync(MenuCategory menuCategory);
        Task DeleteMenuCategoriesAsync(MenuCategory menuCategory);
        #endregion
        

    }
}
