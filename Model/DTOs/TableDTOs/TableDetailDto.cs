using System.ComponentModel.DataAnnotations;

namespace BistroBook.Model.DTOs.TableDTOs
{
    public class TableDetailDto
    {
        public int Id { get; set; }
        public int SeatCount { get; set; }
        public int TableNumber { get; set; }
    }
}
