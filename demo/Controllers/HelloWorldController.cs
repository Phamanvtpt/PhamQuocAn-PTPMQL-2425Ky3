using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        public string Index()
        {
            return "This is my default action...";
        }
        // GET: /HelloWorld/Welcome/
        public string Welcome()
        {
            return "Welcome to the HelloWorld controller!";
        }
    }

}