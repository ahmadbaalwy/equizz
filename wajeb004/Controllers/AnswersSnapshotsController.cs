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

namespace wajeb004.Controllers
{
    public class AnswersSnapshotsController : Controller
    {
        private WajebContext db = new WajebContext();

        // GET: AnswersSnapshots
        
        public async Task<ActionResult> NewSnapShot(int? studentId, int? quizzId)
        {
            AnswersSnapshot answersSnapshot = new AnswersSnapshot();
            answersSnapshot.student = db.Students.Find(studentId);
            answersSnapshot.quizz = db.Quizzs.Find(quizzId);
            answersSnapshot.createdOn = DateTime.Now;
            answersSnapshot.lastChangedOn = DateTime.Now;
            db.AnswersSnapshots.Add(answersSnapshot);

            var selectedQuestions = (from a in db.Questions
                                  where a.quizz.ID == quizzId
                                  select a).ToList();
            int temp = 1;
            foreach (var item in selectedQuestions)
            {
                
                Answer newAnswer = new Answer();
                newAnswer.answersSnapshot = answersSnapshot;
                newAnswer.question = item;
                newAnswer.TrueOrFalseAnswer = null;
                newAnswer.questionSequence = temp;
                if (temp == selectedQuestions.Count())
                {
                    newAnswer.isLastQuestion = true;
                }
                temp = temp + 1;
                db.Answers.Add(newAnswer);
            }
            await db.SaveChangesAsync();
            return View(answersSnapshot);
        }

        public async Task<ActionResult> ResumeSnapShot(int? snapshotId)
        {
            AnswersSnapshot answerSnapshot = await db.AnswersSnapshots.FindAsync(snapshotId);
            return View("NewSnapShot", answerSnapshot);
        }
        public async Task<ActionResult> Index()
        {
            return View(await db.AnswersSnapshots.ToListAsync());
        }

        // GET: AnswersSnapshots/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswersSnapshot answersSnapshot = await db.AnswersSnapshots.FindAsync(id);
            if (answersSnapshot == null)
            {
                return HttpNotFound();
            }
            return View(answersSnapshot);
        }

        // GET: AnswersSnapshots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnswersSnapshots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,status,createdOn,lastChangedOn")] AnswersSnapshot answersSnapshot)
        {
            if (ModelState.IsValid)
            {
                db.AnswersSnapshots.Add(answersSnapshot);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(answersSnapshot);
        }

        // GET: AnswersSnapshots/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswersSnapshot answersSnapshot = await db.AnswersSnapshots.FindAsync(id);
            if (answersSnapshot == null)
            {
                return HttpNotFound();
            }
            return View(answersSnapshot);
        }

        // POST: AnswersSnapshots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,status,createdOn,lastChangedOn")] AnswersSnapshot answersSnapshot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answersSnapshot).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(answersSnapshot);
        }

        // GET: AnswersSnapshots/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswersSnapshot answersSnapshot = await db.AnswersSnapshots.FindAsync(id);
            if (answersSnapshot == null)
            {
                return HttpNotFound();
            }
            return View(answersSnapshot);
        }

        // POST: AnswersSnapshots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AnswersSnapshot answersSnapshot = await db.AnswersSnapshots.FindAsync(id);
            db.AnswersSnapshots.Remove(answersSnapshot);
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
