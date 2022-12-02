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
    public class edu_dtl_tblController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: edu_dtl_tbl
        public ActionResult Index()
        {
            var edu_dtl_tbl = db.edu_dtl_tbl.Include(e => e.Edu_tbl);
            return View(edu_dtl_tbl.ToList());
        }

        // GET: edu_dtl_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edu_dtl_tbl edu_dtl_tbl = db.edu_dtl_tbl.Find(id);
            if (edu_dtl_tbl == null)
            {
                return HttpNotFound();
            }
            return View(edu_dtl_tbl);
        }

        // GET: edu_dtl_tbl/Create
        public ActionResult Create()
        {
            ViewBag.edu_id = new SelectList(db.Edu_tbl, "Id", "Id");
            return View();
        }

        // POST: edu_dtl_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,edu_id,Passing_year,Grade,Percentage")] edu_dtl_tbl edu_dtl_tbl)
        {
            if (ModelState.IsValid)
            {
                db.edu_dtl_tbl.Add(edu_dtl_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.edu_id = new SelectList(db.Edu_tbl, "Id", "Id", edu_dtl_tbl.edu_id);
            return View(edu_dtl_tbl);
        }

        // GET: edu_dtl_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edu_dtl_tbl edu_dtl_tbl = db.edu_dtl_tbl.Find(id);
            if (edu_dtl_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.edu_id = new SelectList(db.Edu_tbl, "Id", "Id", edu_dtl_tbl.edu_id);
            return View(edu_dtl_tbl);
        }

        // POST: edu_dtl_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,edu_id,Passing_year,Grade,Percentage")] edu_dtl_tbl edu_dtl_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edu_dtl_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.edu_id = new SelectList(db.Edu_tbl, "Id", "Id", edu_dtl_tbl.edu_id);
            return View(edu_dtl_tbl);
        }

        // GET: edu_dtl_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edu_dtl_tbl edu_dtl_tbl = db.edu_dtl_tbl.Find(id);
            if (edu_dtl_tbl == null)
            {
                return HttpNotFound();
            }
            return View(edu_dtl_tbl);
        }

        // POST: edu_dtl_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            edu_dtl_tbl edu_dtl_tbl = db.edu_dtl_tbl.Find(id);
            db.edu_dtl_tbl.Remove(edu_dtl_tbl);
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
