using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BistroBook.Model
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        [Required]
        public int GuestCount { get; set; }

        [ForeignKey(nameof(Customer))]
        public int FK_CustomerID { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey(nameof(Table))]
        public int FK_TableID { get; set; }
        public Table Table { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }
    }
}
