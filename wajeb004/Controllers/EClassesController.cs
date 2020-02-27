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
using Microsoft.AspNet.Identity;

namespace wajeb004.Controllers
{
    public class EClassesController : Controller
    {
        private WajebContext db = new WajebContext();

        // GET: EClasses
        public async Task<ActionResult> Index(int courseId)
        {
            //return View(await db.EClasses.ToListAsync());
            Session["courseId"] = courseId;
            
            var allEClasses = await db.EClasses.ToListAsync();
            var myEClasses = new List<EClass>();
            foreach (var item in allEClasses)
            {
                if (item.course.ID == courseId)
                {
                    myEClasses.Add(item);
                }
            }
            return View(myEClasses);
        }

        // GET: EClasses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            Session["eClassId"] = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EClass eClass = await db.EClasses.FindAsync(id);
            if (eClass == null)
            {
                return HttpNotFound();
            }
            return View(eClass);
        }

        // GET: EClasses/Create
        public ActionResult Create(int courseId)
        {
            Session["courseId"] = courseId;
            return View();
        }

        // POST: EClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,EClassName,year,grade,UserID,description")] EClass eClass)
        {
            if (ModelState.IsValid)
            {
                Course newCourse = db.Courses.Find(Convert.ToInt32(Session["courseId"]));
                eClass.course = db.Courses.Find(Convert.ToInt32(Session["courseId"]));
                db.EClasses.Add(eClass);

                await db.SaveChangesAsync();
                return RedirectToAction("Index",new { courseId = eClass.course.ID });
            }

            return View(eClass);
        }

        // GET: EClasses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EClass eClass = await db.EClasses.FindAsync(id);
            if (eClass == null)
            {
                return HttpNotFound();
            }
            return View(eClass);
        }

        // POST: EClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,EClassName,year,grade,UserID,description")] EClass eClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eClass).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(eClass);
        }

        // GET: EClasses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EClass eClass = await db.EClasses.FindAsync(id);
            if (eClass == null)
            {
                return HttpNotFound();
            }
            return View(eClass);
        }

        // POST: EClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EClass eClass = await db.EClasses.FindAsync(id);
            db.EClasses.Remove(eClass);
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
