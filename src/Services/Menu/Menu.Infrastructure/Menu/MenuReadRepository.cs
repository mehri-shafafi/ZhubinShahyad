using Menus.Domain.Menu.Models;
using Menus.Domain.Menu.Repositories;
using Menus.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Menus.Domain.Menu
{
    public class MenuReadRepository : IMenuReadRepository
    {
        private readonly MenuDbContext _dbContext;
        public MenuReadRepository(MenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MenuCategory>> FetchAllMenuCategoryAsync()
        {
            return await _dbContext.MenuCategories.Include(p => p.Id).ToListAsync();
        }
        public async Task<MenuCategory> FetchMenuCategoryAsync(int id)
        {
            return await _dbContext.MenuCategories.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<MenuItem>> FetchAllMenuEntityAsync()
        {
            return await _dbContext.MenuItems.Include(p=>p.Id).ToListAsync();
        }
        public async Task<MenuItem> FetchMenuEntityAsync(int id)
        {
            return await _dbContext.MenuItems.FirstOrDefaultAsync(p => p.Id == id);
        }

      
    }
}
