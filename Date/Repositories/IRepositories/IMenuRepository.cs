using BistroBook.Model;

namespace BistroBook.Date.Repositories.IRepositories
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetAllMenuDishesAsync();
        Task<Menu> GetDishByIdAsync(int menuId);
        Task AddDishAsync(Menu menu);
        Task UpdateMenuAsync(Menu menu);
        Task DeleteDishAsync(int menuId);
    }
}
