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
    public class Course_tblController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Course_tbl
        public ActionResult Index()
        {
            return View(db.Course_tbl.ToList());
        }

        // GET: Course_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_tbl course_tbl = db.Course_tbl.Find(id);
            if (course_tbl == null)
            {
                return HttpNotFound();
            }
            return View(course_tbl);
        }

        // GET: Course_tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,Credit_hr,Course_id")] Course_tbl course_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Course_tbl.Add(course_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course_tbl);
        }

        // GET: Course_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_tbl course_tbl = db.Course_tbl.Find(id);
            if (course_tbl == null)
            {
                return HttpNotFound();
            }
            return View(course_tbl);
        }

        // POST: Course_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,Credit_hr,Course_id")] Course_tbl course_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course_tbl);
        }

        // GET: Course_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_tbl course_tbl = db.Course_tbl.Find(id);
            if (course_tbl == null)
            {
                return HttpNotFound();
            }
            return View(course_tbl);
        }

        // POST: Course_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course_tbl course_tbl = db.Course_tbl.Find(id);
            db.Course_tbl.Remove(course_tbl);
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
