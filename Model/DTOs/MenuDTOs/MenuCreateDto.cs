using System.ComponentModel.DataAnnotations;

namespace BistroBook.Model.DTOs.MenuDTOs
{
    public class MenuCreateDto
    {
        public int Price { get; set; }
        public string DishName { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
    }
}
