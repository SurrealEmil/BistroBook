using System.ComponentModel.DataAnnotations;

namespace BistroBook.Model
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }

        [Required]
        [Range(1, 100)]
        public int SeatCount { get; set; }

        [Required]
        [Range(1, 1000)]
        public int TableNumber { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
