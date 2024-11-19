using AppDev.API.Models.DataTransferObject.Student;
using AppDev.API.Models.DataTransferObject.User;
using AppDev.API.Models.DataTransferObject.UserAndStudent;
using AppDev.API.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Diagnostics;

namespace AppDev.API.Models.Mapper
{
    public class UserMapper
    {
        public static UserDTO ConvertToDTO(User user)
        {
            return new UserDTO
            {
                Email = user.Email,
                Password = user.Password,
                IsActive = user.IsActive,
            };
        }

        public static User ConvertFromDTO(UserDTO dto)
        {
            Debug.WriteLine($"UserDTO in Mapper: {dto.ToString()}");
            return new User
            {
                Email = dto.Email,
                Password = dto.Password,
                IsActive = dto.IsActive,
            };
        }
    }
}
