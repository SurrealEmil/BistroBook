using System.ComponentModel.DataAnnotations;

namespace BistroBook.Model
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 7)]
        public int PhoneNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress] // Validates that the email is in a correct format
        [StringLength(100)]
        public string Email { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
