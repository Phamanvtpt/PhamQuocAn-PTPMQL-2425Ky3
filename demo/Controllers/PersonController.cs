using Microsoft.AspNetCore.Mvc;
// Ensure that the namespace matches the actual namespace of your Person class.
// For example, if your Person class is in FirstWebMVC.Models, keep this line.
// If not, update it to the correct namespace, such as:
using FirstWebMVC.Models;
using System.Text.Encodings.Web;
namespace FirstWebMVC.Controllers;
    public class PersonController : Controller
{
    // GET: /Person/
    public IActionResult Index()
    {
        return View();
    }

    // GET: /Person/Details/
    public IActionResult Details()
    {
        Person person = new Person
        {
            PersonId = "2121050503",
            FullName = "Pham Quôc An"
        };
        return View(person);
    }
}