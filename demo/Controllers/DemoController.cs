using Microsoft.AspNetCore.Mvc;

namespace Demo.Demo.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult SendData(string fullname)
        {
            string Output = "Hello" + fullname;
            ViewBag.Message = Output;
            return View();
        }
    }
}