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
    public class AnswersController : Controller
    {
        private WajebContext db = new WajebContext();

        // GET: Answers
        public async Task<ActionResult> Index()
        {
            return View(await db.Answers.ToListAsync());
        }

        // GET: Answers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = await db.Answers.FindAsync(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // GET: Answers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,TrueOrFalseAnswer,MCQAnswer,OpenQuestionAnswer")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Answers.Add(answer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(answer);
        }

        // GET: Answers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = await db.Answers.FindAsync(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            
            if (answer.isLastQuestion)
            {
                return RedirectToAction("EditLastAnswer",new { id = answer.ID });
            }

            return View(answer);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,TrueOrFalseAnswer,MCQAnswer,OpenQuestionAnswer,questionSequence")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(answer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("editNextAnswer",new { answerId = answer.ID });
            }
            return View(answer);
        }

        public async Task<ActionResult> editNextAnswer(int answerId)
        {
            
            Answer currentAnswer = await db.Answers.FindAsync(answerId);
            int nextSequence = currentAnswer.questionSequence + 1;
            var nextAnswer = (from a in db.Answers
                                where (a.answersSnapshot.ID == currentAnswer.answersSnapshot.ID) && (a.questionSequence == nextSequence)
                                select a).FirstOrDefault();
            

            return RedirectToAction("Edit", new { id = nextAnswer.ID });
        }

        public async Task<ActionResult> EditLastAnswer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = await db.Answers.FindAsync(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: Answers/EditLastAnswer/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditLastAnswer([Bind(Include = "ID,TrueOrFalseAnswer,MCQAnswer,OpenQuestionAnswer,questionSequence,isLastQuestion")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("SubmitSnapshot", "AnswersSnapshots", new { answerId = answer.ID });
            }
            return View(answer);
        }

        // GET: Answers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = await db.Answers.FindAsync(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Answer answer = await db.Answers.FindAsync(id);
            db.Answers.Remove(answer);
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
