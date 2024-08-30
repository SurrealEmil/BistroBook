﻿using BistroBook.Date.Repositories.IRepositories;
using BistroBook.Model;
using BistroBook.Model.DTOs.MenuDTOs;
using BistroBook.Services.IServices;

namespace BistroBook.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        // Add a new dish
        public async Task AddDishAsync(MenuCreateDto menu)
        {
            var newMenuItem = new Menu
            {
                DishName = menu.DishName,
                Description = menu.Description,
                Price = menu.Price,
                IsAvailable = menu.IsAvailable,
            };
            await _menuRepository.AddDishAsync(newMenuItem);
        }

        // Delete a dish by its ID
        public async Task DeleteDishAsync(int menuId)
        {
            var menu = await _menuRepository.GetDishByIdAsync(menuId);
            if (menu == null)
            {
                throw new InvalidOperationException("Dish was not found.");
            }

            await _menuRepository.DeleteDishAsync(menu);
        }

        // Get all dishes and map to summary DTOs
        public async Task<IEnumerable<MenuSummaryDto>> GetAllMenuDishesAsync()
        {
            var menuList = await _menuRepository.GetAllMenuDishesAsync();
            return menuList.Select(m => new MenuSummaryDto
            {
                MenuId = m.MenuId,
                DishName = m.DishName,
                Price = m.Price,
                IsAvailable = m.IsAvailable,
            }).ToList();
        }

        // Get a dish by its ID and map to detail DTO
        public async Task<MenuDetailDto> GetDishByIdAsync(int menuId)
        {
            var menu = await _menuRepository.GetDishByIdAsync(menuId);
            if (menu == null)
            {
                return null;
            }

            return new MenuDetailDto
            {
                MenuId = menu.MenuId,
                DishName = menu.DishName,
                Description = menu.Description,
                Price = menu.Price,
                IsAvailable = menu.IsAvailable,
            };
        }

        // Update an existing dish by its ID
        public async Task UpdateMenuAsync(int menuId, MenuUpdateDto menu)
        {
            var updateMenu = await _menuRepository.GetDishByIdAsync(menuId);
            if (updateMenu == null)
            {
                throw new InvalidOperationException("Dish was not found.");
            }
            updateMenu.DishName = menu.DishName;
            updateMenu.Description = menu.Description;
            updateMenu.Price = menu.Price;
            updateMenu.IsAvailable = menu.IsAvailable;

            await _menuRepository.UpdateMenuAsync(updateMenu);
        }
    }
}