using BistroBook.Model.DTOs.CustomerDTOs;
using BistroBook.Model;
using BistroBook.Services;
using BistroBook.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BistroBook.Model.DTOs.MenuDTOs;

namespace BistroBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [Route("GetAllMenuDishes")]
        public async Task<ActionResult<IEnumerable<Menu>>> GetAllMenuDishes()
        {
            var menuList = await _menuService.GetAllMenuDishesAsync();
            return Ok(menuList);
        }

        [HttpGet]
        [Route("GetDishById/{menuId}")]
        public async Task<ActionResult<Menu>> GetDishById(int menuId)
        {
            var menu = await _menuService.GetDishByIdAsync(menuId);
            return Ok(menu);
        }

        [HttpPost]
        [Route("AddDish")]
        public async Task<ActionResult> AddDish([FromBody] MenuCreateDto menu)
        {
            await _menuService.AddDishAsync(menu);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateMenu/{menuId}")]
        public async Task<ActionResult> UpdateMenu(int menuId, [FromBody] MenuUpdateDto menu)
        {
            await _menuService.UpdateMenuAsync(menuId, menu);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteDish/{menuId}")]
        public async Task<ActionResult<Menu>> DeleteDish([FromBody] int menuId)
        {
            await _menuService.DeleteDishAsync(menuId);
            return Ok();
        }
    }
}
