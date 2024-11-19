using AppDev.API.Data;
using AppDev.API.Models.DataTransferObject.User;
using AppDev.API.Models.DataTransferObject.UserAndStudent;
using AppDev.API.Models.Mapper;
using AppDev.API.Models.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly UserService userService;
        public UsersController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            userService = new UserService(this.applicationDbContext);
        }

        [HttpGet]
        public IActionResult GetAllUsers() {
            return Ok(applicationDbContext.Users.ToList()); // 200
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetUserById(Guid id) {
            var user = applicationDbContext.Users.Find(id);
            return (user is null) ? Ok() : NotFound();
        }
        [HttpPost]
        //public IActionResult AddUser(AddUserDTO addUserDTO)
        //{
        //    var newUser = UserMapper.ConvertFromDTO(addUserDTO);
        //    applicationDbContext.Users.Add(newUser);
        //    applicationDbContext.SaveChanges();
        //    return CreatedAtAction( // 201
        //        nameof(GetUserById),
        //        new { id = newUser.UserIdentification },
        //        newUser
        //        );
        //}
        [HttpPost]
        public async Task<IActionResult> AddUserAndStudent(UserAndStudentDTO userAndStudentDTO)
        {
            try
            {
                var result = await userService.AddUserAndStudentAsync(userAndStudentDTO);
                if (!result.Success) return BadRequest(result.ErrorMessage);

                return CreatedAtAction(
                    nameof(GetUserById),
                    new { id = result.user.StudentIdentification },
                    result.user
                    );
            }
            catch (Exception ex)
            {
                // Log the exception details for more information
                // This will help to see the inner exception message
                return BadRequest("An error occurred: " + ex.Message + "\nInner Exception: " + ex.InnerException?.Message);
            }
        }
        [HttpPut("{id:guid}/update")]
        public IActionResult UpdateUserById(Guid id, UpdateUserDTO updateUserDTO) {
            var user = applicationDbContext.Users.Find(id);
            if(user is null) return NotFound();
            if (!string.IsNullOrEmpty(updateUserDTO.Email))
            {
                user.Email = updateUserDTO.Email;
            }
            if (!string.IsNullOrEmpty(updateUserDTO.Password))
            {
                user.Password = updateUserDTO.Password;
            }
            if (user.IsActive != updateUserDTO.IsActive)
            {
                user.IsActive = updateUserDTO.IsActive;
            }
            applicationDbContext.SaveChanges();
            return Ok(user);
        }
        [HttpPut("{id:guid}/toggle-alive")]
        public IActionResult UpdateUserIsAlive(Guid id) {
            var user = applicationDbContext.Users.Find(id);
            if (user is null) return NotFound();
            user.IsActive = !user.IsActive;
            applicationDbContext.SaveChanges();
            return Ok(user);
        }
    }
}
