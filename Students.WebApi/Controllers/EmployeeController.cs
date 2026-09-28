using Microsoft.AspNetCore.Mvc;
using Students.WebApi.Models;

namespace Students.WebApi.Controllers;

[ApiController]
[Route("api/Employee")]
public class EmployeeController : ControllerBase
{
    private static List<Employee> _employees = new List<Employee>
    {
        new Employee
        {
            EmployeeId = Guid.Parse("6E45FF9B-D5EE-4EF4-82A8-11933F55E115"),
            Name = "Siraj",
            EmployeeAge = 22,
            Address = "Magadi"
        },
        new Employee
        {
            EmployeeId = Guid.Parse("6E45FF9B-D5EE-4EF4-82A8-11933F55E225"),
            Name = "Saqeeb",
            EmployeeAge = 22,
            Address = "Dubai"
        },  
        new Employee
        {
            EmployeeId =  Guid.Parse("6E45FF9B-D5EE-4EF4-82A8-11933F55E335"),
            Name = "Mueez",
            EmployeeAge = 21,
            Address = "America"
        },
           new Employee
        {
            EmployeeId =  Guid.Parse("6E45FF9B-D5EE-4EF4-82A8-11933F55E115"),
            Name = "Kaif",
            EmployeeAge = 23,
            Address = "Africa"
        },
    };
    [HttpGet]
    public IActionResult GetAllEmployee()
    {
        var EmployeeDetails = _employees.ToList();
        return Ok(EmployeeDetails);
    }
    [HttpGet("{id}")]
    public IActionResult GetEmployee(Guid Id)
    {
       var Employee = _employees.FirstOrDefault(e => e.EmployeeId == Id);
        if(Employee == null)
        {
            return BadRequest("Employee not found in List");
        }
        return Ok(Employee);
    }
    [HttpPost]
    public IActionResult CreatEmployee([FromBody] Employee employee)
    {
        //validation
        var filtered = _employees.FirstOrDefault(e => e.Name == employee.Name);
        if (filtered != null)
        {
            return BadRequest("UserName already exists");
        }
        employee.EmployeeId = Guid.NewGuid();

        _employees.Add(employee); 

        
        return Content("Successfully Created New Employee");
    }
}
