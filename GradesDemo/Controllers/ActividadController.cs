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

        // GET: ActividadController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var actividad = await db.Actividad
                                  .Include(a => a.Subject)
                                  .FirstOrDefaultAsync(a => a.Id == id);

            if (actividad == null)
            {
                return NotFound();
            }
            return View(actividad);
        }

        // POST: ActividadController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var actividad = await db.Actividad.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }

            db.Actividad.Remove(actividad);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: SubjectController1/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Subject? subject = await db.Subject.FindAsync(id);
            if (subject != null)
            {
                return View(subject);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.Actividad.Update(actividad);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(actividad);
            }
        }
     }
}