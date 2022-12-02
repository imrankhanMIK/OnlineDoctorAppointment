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
    public class work_dtl_tblController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: work_dtl_tbl
        public ActionResult Index()
        {
            var work_dtl_tbl = db.work_dtl_tbl.Include(w => w.work_tbl);
            return View(work_dtl_tbl.ToList());
        }

        // GET: work_dtl_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            work_dtl_tbl work_dtl_tbl = db.work_dtl_tbl.Find(id);
            if (work_dtl_tbl == null)
            {
                return HttpNotFound();
            }
            return View(work_dtl_tbl);
        }

        // GET: work_dtl_tbl/Create
        public ActionResult Create()
        {
            ViewBag.work_id = new SelectList(db.work_tbl, "Id", "Id");
            return View();
        }

        // POST: work_dtl_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,work_id,Company_name,Job_title,Start_year,End_year,Job_description")] work_dtl_tbl work_dtl_tbl)
        {
            if (ModelState.IsValid)
            {
                db.work_dtl_tbl.Add(work_dtl_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.work_id = new SelectList(db.work_tbl, "Id", "Id", work_dtl_tbl.work_id);
            return View(work_dtl_tbl);
        }

        // GET: work_dtl_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            work_dtl_tbl work_dtl_tbl = db.work_dtl_tbl.Find(id);
            if (work_dtl_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.work_id = new SelectList(db.work_tbl, "Id", "Id", work_dtl_tbl.work_id);
            return View(work_dtl_tbl);
        }

        // POST: work_dtl_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,work_id,Company_name,Job_title,Start_year,End_year,Job_description")] work_dtl_tbl work_dtl_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work_dtl_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.work_id = new SelectList(db.work_tbl, "Id", "Id", work_dtl_tbl.work_id);
            return View(work_dtl_tbl);
        }

        // GET: work_dtl_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            work_dtl_tbl work_dtl_tbl = db.work_dtl_tbl.Find(id);
            if (work_dtl_tbl == null)
            {
                return HttpNotFound();
            }
            return View(work_dtl_tbl);
        }

        // POST: work_dtl_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            work_dtl_tbl work_dtl_tbl = db.work_dtl_tbl.Find(id);
            db.work_dtl_tbl.Remove(work_dtl_tbl);
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
