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
    public class work_tblController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: work_tbl
        public ActionResult Index()
        {
            var work_tbl = db.work_tbl.Include(w => w.Canditate_info1);
            return View(work_tbl.ToList());
        }

        // GET: work_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            work_tbl work_tbl = db.work_tbl.Find(id);
            if (work_tbl == null)
            {
                return HttpNotFound();
            }
            return View(work_tbl);
        }

        // GET: work_tbl/Create
        public ActionResult Create()
        {
            ViewBag.Candidate_id = new SelectList(db.Canditate_info, "Id", "Name");
            return View();
        }

        // POST: work_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Candidate_id")] work_tbl work_tbl)
        {
            if (ModelState.IsValid)
            {
                db.work_tbl.Add(work_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Candidate_id = new SelectList(db.Canditate_info, "Id", "Name", work_tbl.Candidate_id);
            return View(work_tbl);
        }

        // GET: work_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            work_tbl work_tbl = db.work_tbl.Find(id);
            if (work_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Candidate_id = new SelectList(db.Canditate_info, "Id", "Name", work_tbl.Candidate_id);
            return View(work_tbl);
        }

        // POST: work_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Candidate_id")] work_tbl work_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Candidate_id = new SelectList(db.Canditate_info, "Id", "Name", work_tbl.Candidate_id);
            return View(work_tbl);
        }

        // GET: work_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            work_tbl work_tbl = db.work_tbl.Find(id);
            if (work_tbl == null)
            {
                return HttpNotFound();
            }
            return View(work_tbl);
        }

        // POST: work_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            work_tbl work_tbl = db.work_tbl.Find(id);
            db.work_tbl.Remove(work_tbl);
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
