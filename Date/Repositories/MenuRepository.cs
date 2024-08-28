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

        public async Task AddDishAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDishAsync(int menuId)
        {
            var menu = await _context.Menus.FindAsync(menuId);
            if (menu != null)
            {
                _context.Menus.Remove(menu);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Menu>> GetAllMenuDishesAsync()
        {
            var menuList = await _context.Menus.ToListAsync();
            return menuList;
        }

        public async Task<Menu> GetDishByIdAsync(int menuId)
        {
            var menu = await _context.Menus.FindAsync(menuId);
            return menu;
        }

        public async Task UpdateMenuAsync(Menu menu)
        {
            _context.Menus.Update(menu);
            await _context.SaveChangesAsync();
        }
    }
}
