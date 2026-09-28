namespace Students.WebApi.Models;

public class Employee
{
    public  Guid EmployeeId {  get; set; }
    public string? Name {  get; set; }
    public int EmployeeAge { get; set; }
    public string? Address {  get; set; }

}
