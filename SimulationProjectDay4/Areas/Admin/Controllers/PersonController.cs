using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimulationProjectDay4.DataAccessLayer;
using SimulationProjectDay4.Models;
using SimulationProjectDay4.ViewModels.Persons;
using System.Reflection;

namespace SimulationProjectDay4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonController(MosaicDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var datas = await _context.Persons.Select(x => new PersonGetVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PositionName = x.Position.Name,
                ImageUrl = x.ImageUrl
            }).ToListAsync();
            return View(datas);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Positions = await _context.Positions.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonCreateVM vm)
        {
            ViewBag.Psitions = await _context.Positions.ToListAsync();
            //if (vm.ImageFile != null)
            //{
            //    if (!vm.ImageFile.ContentType.StartsWith("image"))
            //        ModelState.AddModelError("ImageFile", "File type must be image");
            //    if (!((vm.ImageFile.Length / 1024) > 500))
            //        ModelState.AddModelError("ImageFile", "File size must be less than 200kb ");
            //}
            if (!ModelState.IsValid)
                return View();
            if (!await _context.Positions.AnyAsync(x => x.Id == vm.PositionId))
            {
                ModelState.AddModelError("PositionId", "Position does not exit");
                ViewBag.Positions = await _context.Positions.ToListAsync();
                return View(vm);
            }
            string newImgName = Guid.NewGuid().ToString() + vm.ImageFile!.FileName;
            string path = Path.Combine("wwwroot", "imgs", "persons", newImgName);
            using FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            await vm.ImageFile.CopyToAsync(fs);
            Person person = new()
            {
                Name = vm.Name,
                Description = vm.Description,
                PositionId = vm.PositionId,
                ImageUrl = newImgName,
            };
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {

            if (!id.HasValue || id.Value < 1)
                return BadRequest();
            ViewBag.Positions = await _context.Positions.ToListAsync();
            var person = await _context.Persons.Where(x => x.Id == id).Select(x => new PersonUpdateVM
            {
                Name = x.Name,
                Description = x.Description,
                PositionId = x.PositionId,
            }).FirstOrDefaultAsync();
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, PersonUpdateVM vm)
        {
            ViewBag.Positions = await _context.Positions.ToListAsync();
            if (!id.HasValue || id.Value < 1)
                return BadRequest();
            if (vm.ImageFile != null)
            {
                if (!vm.ImageFile.ContentType.StartsWith("image"))
                    ModelState.AddModelError("ImageFile", "File type must be image");
                if (((vm.ImageFile.Length) > 2 * 1024 * 1024))
                    ModelState.AddModelError("ImageFile", "File size must be less than 200kb ");
            }
            if (!ModelState.IsValid)
                return View(vm);
            if (!await _context.Positions.AnyAsync(x => x.Id == vm.PositionId))
            {
                ModelState.AddModelError("PositionId", "Position does not exit");
                ViewBag.Positions = await _context.Positions.ToListAsync();
                return View(vm);
            }
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
                return NotFound();
            if (vm.ImageFile != null)
            {

                string newImgName = Guid.NewGuid().ToString() + vm.ImageFile.FileName;
                string path = Path.Combine("wwwroot", "imgs", "persons", newImgName);
                using FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                await vm.ImageFile.CopyToAsync(fs);
                person.ImageUrl = newImgName;
            }
            person.Name = vm.Name;
            person.Description = vm.Description;
            person.PositionId = vm.PositionId;
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue || id.Value < 1)
                return BadRequest();
            var result = await _context.Persons.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (result == 0)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
