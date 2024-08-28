using BistroBook.Model;
using BistroBook.Model.DTOs.MenuDTOs;

namespace BistroBook.Services.IServices
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuSummaryDto>> GetAllMenuDishesAsync();
        Task<MenuDetailDto> GetDishByIdAsync(int menuId);
        Task AddDishAsync(MenuCreateDto menu);
        Task UpdateMenuAsync(int menuId, MenuUpdateDto menu);
        Task DeleteDishAsync(int menuId);
    }
}
