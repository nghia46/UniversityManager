using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Service;

namespace UniversityManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentService _studentService = new StudentService();
        [HttpGet("ShowAllStudent")]
        public IActionResult getAll()
        {
            var students = _studentService.GetAll().OrderByDescending(s => s.Gpa).ToList();
            if (students.Count == 0) {
                return NotFound();
            }
            return Ok(students);
        }
        [HttpGet("Get Student/{id}")]
        public IActionResult getByID(Guid id) {
            Student stu = _studentService.GetByID(id);
            if(stu  != null) {
                return Ok(stu);
            }
            return BadRequest();
        }
        [HttpPut("Add_Student")]
        public IActionResult Add([FromBody] Student student)
        {
            Student newSt = new Student
            {
                StudentId = Guid.NewGuid(),
                FirstName = student.FirstName,
                LastName = student.LastName,
                Gender = student.Gender,
                Major = student.Major,
                Gpa = student.Gpa,
                DateOfBirth = student.DateOfBirth,
            };
            bool added = _studentService.Add(newSt);
            if(added)
            {
                return Ok(student);
            }
            return BadRequest();
        }

    }
}
