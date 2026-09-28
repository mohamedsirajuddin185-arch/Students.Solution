using Microsoft.AspNetCore.Mvc;
using Students.WebApi.Models;

namespace Students.WebApi.Controllers;

[ApiController]
[Route("api/students")]
public class HomeController : ControllerBase
{
    private  static List<Student> _Students = new List<Student>()
        {
            new Student
            {
                StudentId = Guid.Parse("05EABFD7-7E05-477A-AE6B-203BDDB8B07D"),
                Name = "Siraj",
                TotalMarks = 85,
                Address = "Magadi"
            },
              new Student
            {
                StudentId = Guid.Parse("05EABFD7-7E05-477A-AE6B-203BDDB8B44D"),
                Name = "Saqeeb",
                TotalMarks = 90,
                Address = "Ramanagara"
            },  new Student
            {
                StudentId = Guid.Parse("05EABFD7-7E05-477A-AE6B-203BDDB8B24D"),
                Name = "Mueez",
                TotalMarks = 95,
                Address = "Bangalore"
            },  new Student
            {
                StudentId = Guid.Parse("05EABFD7-7E05-477A-AE6B-203BDDB8B14D"),
                Name = "Kaif",
                TotalMarks = 100,
                Address = "Magadi"
            },
        }; //private  list of students

    //[HttpGet]
    //public IActionResult GetAllStudent()
    //{
    //   var StudentDetails =  _Students.ToList();
    //    return Ok(StudentDetails);
        
    //}
    [HttpGet]
    public IActionResult GetAllStudent()
    {
        var StudentDetails = _Students.ToList();
        return Ok(StudentDetails);
    }

    [HttpGet("{id}")]
    public IActionResult GetStudentByID(Guid? id)
    {
        Student? student = _Students.FirstOrDefault(s => s.StudentId == id);

        if (student == null)
        {
            return NotFound("Student not found in the list");
        }

        return Ok(student);

    }
    //[HttpGet("{name}")]
    //public IActionResult GetStudentName(string? name)
    //{
    //    var StudentName = _Students.FirstOrDefault(s => s.Name == name);
    //        if(StudentName == null)
    //    {
    //        return NotFound("Invalid Name in the List");
    //    }
    //    return Ok(StudentName);
    //}
    [HttpPost]
    public IActionResult CreateStudent([FromBody] Student student)
    {
        //validation
        var filtered = _Students.FirstOrDefault(e => e.Name == student.Name);
        if(filtered != null)
        {
            return BadRequest("UserName already exists");
        }

        //generating new GUID  step1
        student.StudentId = Guid.NewGuid();

        //step2
       _Students.Add(student); //its an dummy list

        //step3
        return Content("Successfully Created New Student");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(Guid? id)
    {
        //step1
        var Deleted = _Students.FirstOrDefault(e => e.StudentId == id);

        //validate
        if(Deleted == null)
        {
            return NotFound("User ID not found");
        }

        //step2
        _Students.Remove(Deleted);

        //step3
        return Content("Deleted Successfully");
    }
}
