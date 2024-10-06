using BistroBook.Date.Repositories.IRepositories;
using BistroBook.Model;
using Microsoft.EntityFrameworkCore;

namespace BistroBook.Date.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly BistroBookContext _context;

        public MenuRepository(BistroBookContext context)
        {
            _context = context;
        }

        // Add a new customer
        public async Task AddDishAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
        }

        // Delete a dish by its ID
        public async Task DeleteDishAsync(Menu menu)
        {
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Menu>> GetAllAvailableMenuDishesAsync()
        {
            var menuAvailable = await _context.Menus.Where(menu => menu.IsAvailable).ToListAsync();
            return menuAvailable;
        }

        // Get all favorite dishes
        public async Task<IEnumerable<Menu>> GetAllFavoriteMenuDishesAsync()
        {
            var menuFavorite = await _context.Menus.Where(menu => menu.IsFavorite).ToListAsync();
            return menuFavorite;
        }

        // Get all dishes
        public async Task<IEnumerable<Menu>> GetAllMenuDishesAsync()
        {
            var menuList = await _context.Menus.ToListAsync();
            return menuList;
        }

        // Get a dish by its ID
        public async Task<Menu> GetDishByIdAsync(int menuId)
        {
            var menu = await _context.Menus.FindAsync(menuId);
            return menu;
        }

        // Update a customer by its ID
        public async Task UpdateMenuAsync(Menu menu)
        {
            _context.Menus.Update(menu);
            await _context.SaveChangesAsync();
        }
    }
}
