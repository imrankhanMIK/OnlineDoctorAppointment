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
    public class Edu_tblController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Edu_tbl
        public ActionResult Index()
        {
            var edu_tbl = db.Edu_tbl.Include(e => e.Canditate_info1);
            return View(edu_tbl.ToList());
        }

        // GET: Edu_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edu_tbl edu_tbl = db.Edu_tbl.Find(id);
            if (edu_tbl == null)
            {
                return HttpNotFound();
            }
            return View(edu_tbl);
        }

        // GET: Edu_tbl/Create
        public ActionResult Create()
        {
            ViewBag.Candidate_id = new SelectList(db.Canditate_info, "Id", "Name");
            return View();
        }

        // POST: Edu_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Candidate_id")] Edu_tbl edu_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Edu_tbl.Add(edu_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Candidate_id = new SelectList(db.Canditate_info, "Id", "Name", edu_tbl.Candidate_id);
            return View(edu_tbl);
        }

        // GET: Edu_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edu_tbl edu_tbl = db.Edu_tbl.Find(id);
            if (edu_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Candidate_id = new SelectList(db.Canditate_info, "Id", "Name", edu_tbl.Candidate_id);
            return View(edu_tbl);
        }

        // POST: Edu_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Candidate_id")] Edu_tbl edu_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edu_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Candidate_id = new SelectList(db.Canditate_info, "Id", "Name", edu_tbl.Candidate_id);
            return View(edu_tbl);
        }

        // GET: Edu_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edu_tbl edu_tbl = db.Edu_tbl.Find(id);
            if (edu_tbl == null)
            {
                return HttpNotFound();
            }
            return View(edu_tbl);
        }

        // POST: Edu_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Edu_tbl edu_tbl = db.Edu_tbl.Find(id);
            db.Edu_tbl.Remove(edu_tbl);
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
