using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace ThucHanhMvc.Models
{
    [Table("Person")]
    public class Person
{
    public string PersonId { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }

    public Person()
    {
        PersonId = string.Empty;          
        FullName = string.Empty; 
        Address = string.Empty;  
    }
}

}

