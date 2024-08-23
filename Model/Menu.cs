using System.ComponentModel.DataAnnotations;

namespace BistroBook.Model
{
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string DishName { get; set; }

        public bool Available { get; set; }
    }
}
