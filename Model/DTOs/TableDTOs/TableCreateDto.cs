using System.ComponentModel.DataAnnotations;

namespace BistroBook.Model.DTOs.TableDTOs
{
    public class TableCreateDto
    {
        [Required]
        [Range(1, 100, ErrorMessage = "Seat count must be between 1 and 100.")]
        public int SeatCount { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Seat count must be between 1 and 1000.")]
        public int TableNumber { get; set; }
    }
}
