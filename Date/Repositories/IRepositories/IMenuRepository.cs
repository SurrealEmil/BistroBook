using BistroBook.Model;

namespace BistroBook.Date.Repositories.IRepositories
{
    public interface IMenuRepository
    {
        // Create a new dish
        Task AddDishAsync(Menu menu);

        // Read operations
        Task<Menu> GetDishByIdAsync(int menuId);
        Task<IEnumerable<Menu>> GetAllMenuDishesAsync();
        Task<IEnumerable<Menu>> GetAllFavoriteMenuDishesAsync();
        Task<IEnumerable<Menu>> GetAllAvailableMenuDishesAsync();

        // Update an existing dish
        Task UpdateMenuAsync(Menu menu);

        // Delete a dish
        Task DeleteDishAsync(Menu menu);
    }
}
