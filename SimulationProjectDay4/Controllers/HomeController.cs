using Microsoft.AspNetCore.Mvc;

namespace SimulationProjectDay4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
