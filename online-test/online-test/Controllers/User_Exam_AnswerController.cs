using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using online_test.Models;

namespace online_test.Controllers
{
    public class User_Exam_AnswerController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: User_Exam_Answer
        public ActionResult Index()
        {
            var user_Exam_Answer = db.User_Exam_Answer.Include(u => u.Canditate_info).Include(u => u.Exam_Schedule).Include(u => u.Question_bank);
            return View(user_Exam_Answer.ToList());
        }

        // GET: User_Exam_Answer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Exam_Answer user_Exam_Answer = db.User_Exam_Answer.Find(id);
            if (user_Exam_Answer == null)
            {
                return HttpNotFound();
            }
            return View(user_Exam_Answer);
        }

        // GET: User_Exam_Answer/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.Canditate_info, "Id", "Name");
            ViewBag.exam_id = new SelectList(db.Exam_Schedule, "Id", "Exam_title");
            ViewBag.Question_id = new SelectList(db.Question_bank, "Id", "Question");
            return View();
        }

        // POST: User_Exam_Answer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,user_id,exam_id,Answer,Question_id,Marks")] User_Exam_Answer user_Exam_Answer)
        {
            if (ModelState.IsValid)
            {
                db.User_Exam_Answer.Add(user_Exam_Answer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.Canditate_info, "Id", "Name", user_Exam_Answer.user_id);
            ViewBag.exam_id = new SelectList(db.Exam_Schedule, "Id", "Exam_title", user_Exam_Answer.exam_id);
            ViewBag.Question_id = new SelectList(db.Question_bank, "Id", "Question", user_Exam_Answer.Question_id);
            return View(user_Exam_Answer);
        }

        // GET: User_Exam_Answer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Exam_Answer user_Exam_Answer = db.User_Exam_Answer.Find(id);
            if (user_Exam_Answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.Canditate_info, "Id", "Name", user_Exam_Answer.user_id);
            ViewBag.exam_id = new SelectList(db.Exam_Schedule, "Id", "Exam_title", user_Exam_Answer.exam_id);
            ViewBag.Question_id = new SelectList(db.Question_bank, "Id", "Question", user_Exam_Answer.Question_id);
            return View(user_Exam_Answer);
        }

        // POST: User_Exam_Answer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,user_id,exam_id,Answer,Question_id,Marks")] User_Exam_Answer user_Exam_Answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Exam_Answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.Canditate_info, "Id", "Name", user_Exam_Answer.user_id);
            ViewBag.exam_id = new SelectList(db.Exam_Schedule, "Id", "Exam_title", user_Exam_Answer.exam_id);
            ViewBag.Question_id = new SelectList(db.Question_bank, "Id", "Question", user_Exam_Answer.Question_id);
            return View(user_Exam_Answer);
        }

        // GET: User_Exam_Answer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Exam_Answer user_Exam_Answer = db.User_Exam_Answer.Find(id);
            if (user_Exam_Answer == null)
            {
                return HttpNotFound();
            }
            return View(user_Exam_Answer);
        }

        // POST: User_Exam_Answer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Exam_Answer user_Exam_Answer = db.User_Exam_Answer.Find(id);
            db.User_Exam_Answer.Remove(user_Exam_Answer);
            db.SaveChanges();
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
