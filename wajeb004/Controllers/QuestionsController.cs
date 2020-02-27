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
    public class QuestionsController : Controller
    {
        private WajebContext db = new WajebContext();

        public async Task<ActionResult> GetQuestions (int quizzId)
        {
            Session["quizzId"] = quizzId;
            var allQuestions = await db.Questions.ToListAsync();
            var someQuestions = new List<Question>();

            foreach (var item in allQuestions)
            {
                if (item.quizz.ID == quizzId)
                {
                    someQuestions.Add(item);
                }
            }

           
            return View(someQuestions.ToList());
        }

        // GET: Questions
        public async Task<ActionResult> Index()
        {
            return View(await db.Questions.ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create(string QuestionType)
        {
            Session["QuestionType"] = QuestionType;
            if (QuestionType == "TF")
            {
                return View("Create_TF");
            }
            else if (QuestionType == "MCQ")
            {
                return View("Create_MCQ");
            }
            else if (QuestionType == "OpenAnswer")
            {
                return View("Create_OpenAnswer");
            }

            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,QuestionText,QuestionType,score,isTrue,opt1,opt2,opt3,opt4,correctOption")] Question question)
        {
            if (ModelState.IsValid)
            {
                question.quizz = db.Quizzs.Find(Convert.ToInt32(Session["quizzId"]));
                question.QuestionType = Session["QuestionType"].ToString();
                db.Questions.Add(question);
                await db.SaveChangesAsync();
                return RedirectToAction("GetQuestions", new { quizzId = Session["quizzId"] });
            }

            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,QuestionText,QuestionType,score,isTrue,opt1,opt2,opt3,opt4,correctOption")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("GetQuestions",new { quizzId = Session["quizzId"] });
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Question question = await db.Questions.FindAsync(id);
            db.Questions.Remove(question);
            await db.SaveChangesAsync();
            return RedirectToAction("GetQuestions", new { quizzId = Session["quizzId"] });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult QuestionTypes()
        {
            return PartialView();
        }
    }
}
