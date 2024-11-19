using AppDev.API.Data;
using AppDev.API.Models.DataTransferObject.Student;
using AppDev.API.Models.DataTransferObject.UserAndStudent;
using AppDev.API.Models.Entities;
using AppDev.API.Models.Mapper;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AppDev.API.Models.Service
{
    public class UserService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<(bool Success, string? ErrorMessage, User user, Student student)> AddUserAndStudentAsync(UserAndStudentDTO userAndStudentDTO) { 
            using var transaction = await applicationDbContext.Database.BeginTransactionAsync();
            try
            {
                // Debugging Step
                Debug.WriteLine($"UserDTO: {userAndStudentDTO.UserDTO.ToString()}");
                Debug.WriteLine($"StudentDTO: {userAndStudentDTO.StudentDTO.ToString()}");

                var newStudent = StudentMapper.ConvertFromDTO(userAndStudentDTO.StudentDTO);
                applicationDbContext.Students.Add(newStudent);
                await applicationDbContext.SaveChangesAsync();

                var newUser = UserMapper.ConvertFromDTO(userAndStudentDTO.UserDTO);
                newUser.StudentIdentification = newStudent.StudentIdentification; ;
                applicationDbContext.Users.Add(newUser);
                await applicationDbContext.SaveChangesAsync();

                await transaction.CommitAsync();
                return (true, null, newUser, newStudent);
            }
            catch (DbUpdateException dbEx)
            {
                // Log the detailed error information for troubleshooting
                var errorMessage = $"An error occurred while updating the database: {dbEx.Message}";
                if (dbEx.InnerException != null)
                {
                    errorMessage += $"\nInner Exception: {dbEx.InnerException.Message}";
                }

                await transaction.RollbackAsync();
                return (false, errorMessage, new User(), new Student());
            }
            catch (Exception ex)
            {
                // General exception catch block for unexpected errors
                await transaction.RollbackAsync();
                return (false, ex.Message, new User(), new Student());
            }
        }
    }
}
