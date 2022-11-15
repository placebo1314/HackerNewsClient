using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Codecool.HackerNewsClient.Controllers
{
    public class HelloWorld : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        //public string Welcome(string name, int id = 1, int numTimes = 2)
        //{
        //    return HtmlEncoder.Default.Encode($"Name: {name}, ID: {id}, numtimes: {numTimes}");
        //}
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
