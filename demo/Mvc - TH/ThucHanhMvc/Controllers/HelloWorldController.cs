using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ThucHanhMvc.Models;

namespace ThucHanhMvc.Controllers
{
    public class HelloWorldController : Controller
    {
        //Get: HelloWorld/
        public IActionResult Index()
        {
            return View();
        }
        //Get: HelloWorld/Welcome/
        public string Welcome()
        {
            return "Hello, World!";
        }
    }
}