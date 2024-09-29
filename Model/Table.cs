using System.ComponentModel.DataAnnotations;

namespace BistroBook.Model
{
    public class Table
    {
        // Primary key
        [Key]
        public int Id { get; set; }

        // Table properties
        [Required]
        [Range(1, 100, ErrorMessage = "Seat count must be between 1 and 100.")]
        public int SeatCount { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Table number must be between 1 and 1000.")]
        public int TableNumber { get; set; }

        // Navigation property
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
