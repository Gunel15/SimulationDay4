using Microsoft.AspNetCore.Mvc;

namespace SimulationProjectDay4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
