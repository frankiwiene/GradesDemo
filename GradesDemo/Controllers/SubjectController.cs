using GradesDemo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GradesDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Antiforgery;

namespace GradesDemo.Controllers
{
    public class SubjectController : Controller
    {
        MySQLDbContext db;
        // GET: SubjectController1

        public SubjectController(MySQLDbContext db) {
            this.db = db;
        }
        public ActionResult Index()
        {            
            return View();
        }

        // GET: SubjectController1/Details/5

        public async Task<ActionResult> Details()
        {
            List<Subject> subjects = await db.Subject.ToListAsync();
            return View(subjects);
        }

        // GET: SubjectController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubjectController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Subject subject)
        {
            if(ModelState.IsValid)
            {
                db.Subject.Add(subject);
                await db.SaveChangesAsync();
                return View("Index");
            }
            return View(subject);
            
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
            else {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Subject subject)
        {
            
            if (ModelState.IsValid)
            {
                db.Subject.Update(subject);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(subject);
            }
        }


        // GET: SubjectController1/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Subject? subject = await db.Subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: SubjectController1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(int id)
        {
            Subject? subject = await db.Subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            db.Subject.Remove(subject);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
