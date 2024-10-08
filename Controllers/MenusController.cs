﻿using BistroBook.Model.DTOs.CustomerDTOs;
using BistroBook.Model;
using BistroBook.Services;
using BistroBook.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BistroBook.Model.DTOs.MenuDTOs;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<ActionResult<IEnumerable<MenuSummaryDto>>> GetAllMenuDishes()
        {
            var menuList = await _menuService.GetAllMenuDishesAsync();

            if (menuList.IsNullOrEmpty())
            {
                return NotFound("No dish found.");
            }

            return Ok(menuList);
        }

        // Get /api/Menus/GetAllAvailableMenuDishes
        [HttpGet]
        [Route("GetAllAvailableMenuDishes")]
        public async Task<ActionResult<IEnumerable<MenuDetailDto>>> GetAllAvailableMenuDishes()
        {
            var menuAvailable = await _menuService.GetAllAvailableMenuDishesAsync();

            if (menuAvailable.IsNullOrEmpty())
            {
                return NotFound("No dish found.");
            }

            return Ok(menuAvailable);
        }

        // Get /api/Menus/GetAllFavoriteMenuDishes
        [HttpGet]
        [Route("GetAllFavoriteMenuDishes")]
        public async Task<ActionResult<IEnumerable<MenuDetailDto>>> GetAllFavoriteMenuDishes()
        {
            var menuFavorite = await _menuService.GetAllFavoriteMenuDishesAsync();

            if (menuFavorite.IsNullOrEmpty())
            {
                return NotFound("No dish found.");
            }

            return Ok(menuFavorite);
        }

        //Get /api/Menus/GetDishById/{id}
        [HttpGet]
        [Route("GetDishById/{id}")]
        public async Task<ActionResult<MenuDetailDto>> GetDishById(int id)
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
        public async Task<ActionResult> DeleteDish(int id)
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
