namespace Students.WebApi.Models;

public class Student
{
    public Guid StudentId { get; set; }
    public string? Name { get; set; }
    public int TotalMarks { get; set; }
    public string? Address { get; set; }

}
