using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppDev.API.Models.DataTransferObject.User
{
    public class UserDTO
    {

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        [MaxLength(256)] // Length constraint for performance and consistency
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        public bool IsActive { get; set; } = true; // Default value for new users

        public override string ToString()
        {
            return $"User: Email = {Email}, IsActive = {IsActive}";
        }
    }
}
