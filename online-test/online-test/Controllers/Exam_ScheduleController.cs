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
    public class Exam_ScheduleController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Exam_Schedule
        public ActionResult Index()
        {
            return View(db.Exam_Schedule.ToList());
        }

        // GET: Exam_Schedule/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam_Schedule exam_Schedule = db.Exam_Schedule.Find(id);
            if (exam_Schedule == null)
            {
                return HttpNotFound();
            }
            return View(exam_Schedule);
        }

        // GET: Exam_Schedule/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exam_Schedule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Exam_date,Exam_title,Exam_duration,Exam_total_question,Exam_status,Course_id")] Exam_Schedule exam_Schedule)
        {
            if (ModelState.IsValid)
            {
                db.Exam_Schedule.Add(exam_Schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exam_Schedule);
        }

        // GET: Exam_Schedule/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam_Schedule exam_Schedule = db.Exam_Schedule.Find(id);
            if (exam_Schedule == null)
            {
                return HttpNotFound();
            }
            return View(exam_Schedule);
        }

        // POST: Exam_Schedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Exam_date,Exam_title,Exam_duration,Exam_total_question,Exam_status,Course_id")] Exam_Schedule exam_Schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam_Schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exam_Schedule);
        }

        // GET: Exam_Schedule/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam_Schedule exam_Schedule = db.Exam_Schedule.Find(id);
            if (exam_Schedule == null)
            {
                return HttpNotFound();
            }
            return View(exam_Schedule);
        }

        // POST: Exam_Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam_Schedule exam_Schedule = db.Exam_Schedule.Find(id);
            db.Exam_Schedule.Remove(exam_Schedule);
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
