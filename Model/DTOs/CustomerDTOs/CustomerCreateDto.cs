using System.ComponentModel.DataAnnotations;

namespace BistroBook.Model.DTOs.CustomerDTOs
{
    public class CustomerCreateDto
    {
        [Required]
        [Phone]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "Phone number must be between 7 and 20 characters.")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email address can be a maximum of 100 characters.")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First name must be between 1 and 50 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name must be between 1 and 50 characters.")]
        public string LastName { get; set; }
    }
}
