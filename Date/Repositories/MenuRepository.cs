using BistroBook.Date.Repositories.IRepositories;
using BistroBook.Model;
using Microsoft.EntityFrameworkCore;

namespace BistroBook.Date.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly BistroBookContext _context;

        public MenuRepository(BistroBookContext contest)
        {
            _context = contest;
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
