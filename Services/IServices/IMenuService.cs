using BistroBook.Model;
using BistroBook.Model.DTOs.MenuDTOs;

namespace BistroBook.Services.IServices
{
    public interface IMenuService
    {
        // Create a new dish
        Task AddDishAsync(MenuCreateDto menu);

        // Read operations
        Task<MenuDetailDto> GetDishByIdAsync(int menuId);
        Task<IEnumerable<MenuSummaryDto>> GetAllMenuDishesAsync();

        // Update an existing dish
        Task UpdateMenuAsync(int menuId, MenuUpdateDto menu);

        // Delete a dish
        Task DeleteDishAsync(int menuId);
    }
}
