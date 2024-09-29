using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BistroBook.Model
{
    public class Reservation
    {
        // Primary key
        [Key]
        public int Id { get; set; }

        // Guest details
        [Required]
        [Range(1, 100, ErrorMessage = "Guest count must be between 1 and 100.")]
        public int GuestCount { get; set; }



        // Foreign key and navigation property for Customer
        [ForeignKey(nameof(Customer))]
        public int FK_CustomerId { get; set; }

        [Required]
        public Customer Customer { get; set; }

        // Foreign key and navigation property for Table
        [ForeignKey(nameof(Table))]
        public int FK_TableId { get; set; }

        [Required]
        public Table Table { get; set; }



        // Reservation details
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
 