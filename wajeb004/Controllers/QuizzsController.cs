using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wajeb004.DAL;
using wajeb004.Models;
using System.Collections;

namespace wajeb004.Controllers
{
    public class QuizzsController : Controller
    {
        private WajebContext db = new WajebContext();

        public async Task<ActionResult> GetQuizzes()
        {
           var allQuizzes = await db.Quizzs.ToListAsync();
           var thisQuizzes = new List<Quizz>();
            int eClassId = Convert.ToInt32(Session["eClassId"]);

            foreach (var item in allQuizzes)
            {
                if (item.eclass.ID == eClassId)
                {
                    thisQuizzes.Add(item);
                }
            }
            
            
            return View(thisQuizzes.ToList());
        }

        // GET: Quizzs
        public async Task<ActionResult> Index()
        {
            return View(await db.Quizzs.ToListAsync());
        }

        // GET: Quizzs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quizz quizz = await db.Quizzs.FindAsync(id);
            if (quizz == null)
            {
                return HttpNotFound();
            }
            return View(quizz);
        }

        // GET: Quizzs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quizzs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,QuizzName")] Quizz quizz)
        {
            if (ModelState.IsValid)
            {
                quizz.eclass = db.EClasses.Find(Convert.ToInt32(Session["eClassId"]));
                
                db.Quizzs.Add(quizz);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(quizz);
        }

        // GET: Quizzs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quizz quizz = await db.Quizzs.FindAsync(id);
            if (quizz == null)
            {
                return HttpNotFound();
            }
            return View(quizz);
        }

        // POST: Quizzs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,QuizzName")] Quizz quizz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quizz).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(quizz);
        }

        // GET: Quizzs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quizz quizz = await db.Quizzs.FindAsync(id);
            if (quizz == null)
            {
                return HttpNotFound();
            }
            return View(quizz);
        }

        // POST: Quizzs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Quizz quizz = await db.Quizzs.FindAsync(id);
            db.Quizzs.Remove(quizz);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
