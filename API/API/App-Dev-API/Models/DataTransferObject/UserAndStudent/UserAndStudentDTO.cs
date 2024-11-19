using AppDev.API.Models.DataTransferObject.Student;
using AppDev.API.Models.DataTransferObject.User;
using System.ComponentModel.DataAnnotations;

namespace AppDev.API.Models.DataTransferObject.UserAndStudent
{
    public class UserAndStudentDTO
    {
        [Required]
        public StudentDTO StudentDTO { get; set; }
        [Required]
        public UserDTO UserDTO { get; set; }
    }
}
