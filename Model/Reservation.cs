using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BistroBook.Model
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        public int GuestCount { get; set; }

        [ForeignKey(nameof(Customer))]
        public int FK_CustomerId { get; set; }
        [Required]
        public Customer Customer { get; set; }

        [ForeignKey(nameof(Table))]
        public int FK_TableId { get; set; }
        [Required]
        public Table Table { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        [Required]
        public ReservationStatus Status { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }

    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Canceled
    }
}
 