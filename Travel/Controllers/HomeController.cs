using Microsoft.AspNet.Mvc;
using Travel.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            //things in this method are just for testing
            Trip testTrip = new Trip();
            //Stop testStop = new Stop();
            testTrip.ID = 69;
            //testStop.ID = 70;
            ViewBag.MessageToUsers = testTrip.ID;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}