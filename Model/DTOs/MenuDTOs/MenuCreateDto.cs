﻿using System.ComponentModel.DataAnnotations;

namespace BistroBook.Model.DTOs.MenuDTOs
{
    public class MenuCreateDto
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Dish name must be between 1 and 50 characters.")]
        public string DishName { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 200 characters.")]
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public int Price { get; set; }

        public bool IsFavorite { get; set; }

        public bool IsAvailable { get; set; }
    }
}
