using AppDev.API.Data;
using Microsoft.AspNetCore.Mvc;
using AppDev.API.Models.Entities;
using AppDev.API.Models.Mapper;
using Microsoft.AspNetCore.Authorization;
using AppDev.API.Models.DataTransferObject.Student;
namespace AppDev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public IActionResult GetAllStudents() {
            var list = applicationDbContext.Students.ToList();
            var studentsDTO = new List<StudentDTO>();
            foreach(var student in list){
                studentsDTO.Add(StudentMapper.ConvertToDTO(student));
            }
            return Ok(studentsDTO); // 200 OK
        }
        //[HttpPost]
        //public IActionResult AddStudent(AddStudentDTO addStudentDTO)
        //{

        //    var newStudent = StudentMapper.ConvertFromDTO(addStudentDTO);
        //    applicationDbContext.Students.Add(newStudent);
        //    applicationDbContext.SaveChanges();
        //    return CreatedAtAction( // 201 Created
        //        nameof(GetStudentById), // Action to get the student (e.g., GetStudentById)
        //        new { id = newStudent.StudentIdentification }, // Pass the student id in route
        //        newStudent // Return the newly created student object
        //    );
        //}
        [HttpGet("{id:guid}")]
        public IActionResult GetStudentById(Guid id) {
            var student = applicationDbContext.Students.Find(id);
            if(student is null) return NotFound();
            return Ok(StudentMapper.ConvertToDTO(student));
        }
        [HttpPut("{id:guid}/update")]
        public IActionResult UpdateStudent(Guid id, UpdateStudentDTO updateStudentDTO) { 
            var student = applicationDbContext.Students.Find(id);
            if (student is null) { 
                return NotFound();
            }
            var updatedStudentInfo = StudentMapper.ConvertFromDTO(updateStudentDTO);
            if (updatedStudentInfo is null) {
                return BadRequest();
            }
            if (!string.IsNullOrEmpty(updatedStudentInfo.FirstName))
            {
                student.FirstName = updatedStudentInfo.FirstName;
            }
            if (!string.IsNullOrEmpty(updatedStudentInfo.LastName))
            {
                student.LastName = updatedStudentInfo.LastName;
            }
            student.Program = updatedStudentInfo.Program;
            student.YearLevel = updatedStudentInfo.YearLevel;
            student.Status = updatedStudentInfo.Status;
            applicationDbContext.SaveChanges();
            return Ok(student);
        }
        //[HttpDelete("{id:guid}")]
        //public IActionResult DeleteStudent(Guid id) { 
        //    var deleteStudent = applicationDbContext.Students.Find(id);
        //    if (deleteStudent is null) {
        //        return NotFound();
        //    }
        //    applicationDbContext.Students.Remove(deleteStudent);
        //    applicationDbContext.SaveChanges();
        //    return Ok();
        //}
    }
}
