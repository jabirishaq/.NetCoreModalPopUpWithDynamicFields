using EvaluationBizsol.Database;
using EvaluationBizsol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvaluationBizsol.ViewModel;

namespace EvaluationBizsol.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly EvaluationDbContext db;

        public DeveloperController(EvaluationDbContext _db)
        {
            db = _db;
        }

        public async Task<IActionResult> Index()
        {
            var devs = await db.Developer.ToListAsync();
            ViewBag.Developers = devs;
            return View();
        }
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public JsonResult Save([FromBody] List<DeveloperDM> dev)
        {
            if (ModelState.IsValid)
            {
               foreach(var d in dev)
                {
                    db.Developer.Add(d);
                    db.SaveChanges();
                }
                //await db.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return Json("success");
            }

            //return View(dev);
            return Json(dev);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
                return BadRequest();

            var dev = await db.Developer.FirstOrDefaultAsync(d=>d.Id == id);

            if (dev == null)
                return NotFound();

            return View(dev);


        }
        [HttpPost]
        public async Task<IActionResult> Edit(DeveloperDM dev)
        {
            if (!ModelState.IsValid)
                return View(dev);
            
                db.Developer.Update(dev);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }
    }
}
