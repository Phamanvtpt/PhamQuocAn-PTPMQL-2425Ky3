using System.ComponentModel.DataAnnotations;
namespace Demo.Models;

public class Employee : Person
{
    public int? EmployeeId { get; set; }
    [DataType(DataType.Date)]
    public int Age { get; set; }
}