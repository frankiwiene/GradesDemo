using GradesDemo.Data;
using GradesDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GradesDemo.Controllers
{
    public class ActividadController : Controller
    {
        MySQLDbContext db;
        public ActividadController(MySQLDbContext db)
        {
            this.db = db;
        }


  

        public ActionResult Index()
        {
            return View();
        }

        // GET: ActividadController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            List<Actividad> actividades = await db.Actividad
                                          .Include(i => i.Subject)
                                          .ToListAsync();
            return View(actividades);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewData["SubjectId"] = new SelectList(
                                    await db.Subject.ToListAsync(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Actividad activity)
        {
            if (ModelState.IsValid)
            {
                db.Actividad.Add(activity);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(
                                        await db.Subject.ToListAsync(), "Id", "Name",
                                        activity.SubjectId);
            return View(activity);
        }


    }
}
