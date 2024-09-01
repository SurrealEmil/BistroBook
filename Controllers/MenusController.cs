using BistroBook.Model.DTOs.CustomerDTOs;
using BistroBook.Model;
using BistroBook.Services;
using BistroBook.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BistroBook.Model.DTOs.MenuDTOs;
using Microsoft.IdentityModel.Tokens;

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

        // Get /api/Menus/GetAllMenuDishes
        [HttpGet]
        [Route("GetAllMenuDishes")]
        public async Task<ActionResult<IEnumerable<Menu>>> GetAllMenuDishes()
        {
            var menuList = await _menuService.GetAllMenuDishesAsync();

            if (menuList.IsNullOrEmpty())
            {
                return NotFound("No dish found.");
            }

            return Ok(menuList);
        }

        //Get /api/Menus/GetDishById/{id}
        [HttpGet]
        [Route("GetDishById/{id}")]
        public async Task<ActionResult<Menu>> GetDishById(int id)
        {
            var menu = await _menuService.GetDishByIdAsync(id);

            if (menu == null)
            {
                return NotFound("No matching dish found.");
            }

            return Ok(menu);
        }

        // Post /api/Menus/AddDish
        [HttpPost]
        [Route("AddDish")]
        public async Task<ActionResult> AddDish([FromBody] MenuCreateDto menu)
        {
            try
            {
                await _menuService.AddDishAsync(menu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Dish added successfully.");
        }

        // Put /api/Menus/UpdateMenu/{id}
        [HttpPut]
        [Route("UpdateMenu/{id}")]
        public async Task<ActionResult> UpdateMenu(int id, [FromBody] MenuUpdateDto menu)
        {
            try
            {
                await _menuService.UpdateMenuAsync(id, menu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Menu updated successfully.");
        }

        // Delete /api/Menus/DeleteDish/{id}
        [HttpDelete]
        [Route("DeleteDish/{id}")]
        public async Task<ActionResult<Menu>> DeleteDish(int id)
        {
            try
            {
                await _menuService.DeleteDishAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Dish deleted successfully.");
        }
    }
}
