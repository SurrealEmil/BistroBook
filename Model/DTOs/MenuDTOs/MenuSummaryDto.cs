namespace BistroBook.Model.DTOs.MenuDTOs
{
    public class MenuSummaryDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string DishName { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsAvailable { get; set; }
    }
}
