using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDev.API.Models.Entities
{
    public class User
    {
        [Key]
        public Guid UserIdentification { get; set; }
        [Required]
        [ForeignKey(nameof(Student))] 
        public Guid StudentIdentification { get; set; }
        public Student Student { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        [MaxLength(256)] // Length constraint for performance and consistency
        public string Email {get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password{get; set;}

        [NotMapped] // Exclude from database, used for validation only
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true; // Default value for new users
    }
}
