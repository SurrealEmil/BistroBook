using System.ComponentModel.DataAnnotations;

namespace BistroBook.Model.DTOs.ReservationDTOs
{
    public class ReservationCreateDto
    {
        [Required]
        public int TableId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int GuestCount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }
    }
}
