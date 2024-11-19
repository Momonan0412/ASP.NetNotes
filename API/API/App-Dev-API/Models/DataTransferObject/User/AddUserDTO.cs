using System.ComponentModel.DataAnnotations;

namespace AppDev.API.Models.DataTransferObject.User
{
    public class AddUserDTO : UserDTO
    {
        [Required(ErrorMessage = "Email address is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        [MaxLength(256)] // Length constraint for performance and consistency
        public new string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]

        public new string Password { get; set; }

        public new bool IsActive { get; set; } = true; // Default value for new users
    }
}
