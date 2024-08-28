namespace BistroBook.Model.DTOs.MenuDTOs
{
    public class MenuSummaryDto
    {
        public int MenuId { get; set; }
        public int Price { get; set; }
        public string DishName { get; set; }
        public bool IsAvailable { get; set; }
    }
}
