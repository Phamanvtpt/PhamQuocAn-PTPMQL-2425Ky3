using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.FirstwebMVC.Controllers
{
    public class DemoControllers : Controller
    {
        public IActionResult SendData(string fullname)
        {
            string Output = "Hello" + fullname;
            ViewBag.Message = Output;
            return View();
        }
    }
}