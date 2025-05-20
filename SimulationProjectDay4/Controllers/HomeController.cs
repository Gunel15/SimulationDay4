using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimulationProjectDay4.DataAccessLayer;
using SimulationProjectDay4.ViewModels;
using SimulationProjectDay4.ViewModels.Persons;
using SimulationProjectDay4.ViewModels.Positions;

namespace SimulationProjectDay4.Controllers
{
    public class HomeController(MosaicDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var persons = await _context.Persons.Select(x => new PersonGetVM
            {
                Name = x.Name,
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Description = x.Description,
                PositionName=x.Position.Name
            }).ToListAsync();

            var positions = await _context.Positions.Select(x => new PositionGetVM
            {
                Name = x.Name,
                Id = x.Id,
            }).ToListAsync();

            HomeVM vm = new()
            {
                Persons = persons,
                Positions = positions
            };
            return View(vm);
        }

    }
}
