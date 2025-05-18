using Menus.Domain.Menu.Models;
using Menus.Domain.Menu.Repositories;
using Menus.Infrastructure;

namespace Menus.Infrastructure.Menu
{
    public class MenuWriteRepository : IMenuWriteRepository
    {
        private readonly MenuDbContext _dbContext;
        public MenuWriteRepository(MenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region 
        public async Task<MenuCategory> AddMenuCategoriesAsync(MenuCategory MenuCategory)
        {
            var result = await _dbContext.AddAsync(MenuCategory);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<MenuCategory?> UpdateMenuCategoriesAsync(MenuCategory menuCategory)
        {
            var existing = await _dbContext.MenuCategories.FindAsync(menuCategory.Id);
            if (existing == null) return null;

            var entry = _dbContext.Entry(existing);
            var properties = typeof(MenuCategory).GetProperties();

            foreach (var prop in properties)
            {
                var newValue = prop.GetValue(menuCategory);
                if (newValue != null)
                {
                    prop.SetValue(existing, newValue);
                }
            }

            await _dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task DeleteMenuCategoriesAsync(MenuCategory MenuCategory)
        {
            var entity = await _dbContext.MenuCategories.FindAsync(MenuCategory.Id);
            if (entity == null)
                throw new Exception("MenuCategory not found");
            entity.Active = false;
            var result = _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
        #region 
        public async Task<MenuItem> AddMenuAsync(MenuItem menuItem)
        {
            var result = await _dbContext.AddAsync(menuItem);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<MenuItem> UpdateMenuAsync(MenuItem menuItem)
        {
            var result = _dbContext.Update(menuItem);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteMenuAsync(MenuItem MenuEntity)
        {
            _dbContext.MenuItems.Remove(MenuEntity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<MenuItem> AddMenuItemAsync(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem> UpdateMenuItemAsync(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMenuItemAsync(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public Task<MenuCategory> UpdateMenuItemAsync(MenuCategory menuCategory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMenuItemAsync(MenuCategory menuCategory)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
