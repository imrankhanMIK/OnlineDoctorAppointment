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
    public class assigned_user_examController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: assigned_user_exam
        public ActionResult Index()
        {
            var assigned_user_exam = db.assigned_user_exam.Include(a => a.Exam_Schedule).Include(a => a.Canditate_info);
            return View(assigned_user_exam.ToList());
        }

        // GET: assigned_user_exam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assigned_user_exam assigned_user_exam = db.assigned_user_exam.Find(id);
            if (assigned_user_exam == null)
            {
                return HttpNotFound();
            }
            return View(assigned_user_exam);
        }

        // GET: assigned_user_exam/Create
        public ActionResult Create()
        {
            ViewBag.exam_id = new SelectList(db.Exam_Schedule, "Id", "Exam_title");
            ViewBag.user_id = new SelectList(db.Canditate_info, "Id", "Name");
            return View();
        }

        // POST: assigned_user_exam/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,user_id,exam_id")] assigned_user_exam assigned_user_exam)
        {
            if (ModelState.IsValid)
            {
                db.assigned_user_exam.Add(assigned_user_exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.exam_id = new SelectList(db.Exam_Schedule, "Id", "Exam_title", assigned_user_exam.exam_id);
            ViewBag.user_id = new SelectList(db.Canditate_info, "Id", "Name", assigned_user_exam.user_id);
            return View(assigned_user_exam);
        }

        // GET: assigned_user_exam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assigned_user_exam assigned_user_exam = db.assigned_user_exam.Find(id);
            if (assigned_user_exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.exam_id = new SelectList(db.Exam_Schedule, "Id", "Exam_title", assigned_user_exam.exam_id);
            ViewBag.user_id = new SelectList(db.Canditate_info, "Id", "Name", assigned_user_exam.user_id);
            return View(assigned_user_exam);
        }

        // POST: assigned_user_exam/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,user_id,exam_id")] assigned_user_exam assigned_user_exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assigned_user_exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.exam_id = new SelectList(db.Exam_Schedule, "Id", "Exam_title", assigned_user_exam.exam_id);
            ViewBag.user_id = new SelectList(db.Canditate_info, "Id", "Name", assigned_user_exam.user_id);
            return View(assigned_user_exam);
        }

        // GET: assigned_user_exam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assigned_user_exam assigned_user_exam = db.assigned_user_exam.Find(id);
            if (assigned_user_exam == null)
            {
                return HttpNotFound();
            }
            return View(assigned_user_exam);
        }

        // POST: assigned_user_exam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            assigned_user_exam assigned_user_exam = db.assigned_user_exam.Find(id);
            db.assigned_user_exam.Remove(assigned_user_exam);
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
