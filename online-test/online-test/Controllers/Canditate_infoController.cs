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
    public class Canditate_infoController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Canditate_info
        public ActionResult Index()
        {
            var canditate_info = db.Canditate_info.Include(c => c.Edu_tbl).Include(c => c.work_tbl);
            return View(canditate_info.ToList());
        }

        // GET: Canditate_info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canditate_info canditate_info = db.Canditate_info.Find(id);
            if (canditate_info == null)
            {
                return HttpNotFound();
            }
            return View(canditate_info);
        }

        // GET: Canditate_info/Create
        public ActionResult Create()
        {
            ViewBag.edu_dtl = new SelectList(db.Edu_tbl, "Id", "Id");
            ViewBag.work_exp = new SelectList(db.work_tbl, "Id", "Id");
            return View();
        }

        // POST: Canditate_info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Cell_no,DOB,Gender,Password,CNIC,edu_dtl,work_exp")] Canditate_info canditate_info)
        {
            if (ModelState.IsValid)
            {
                db.Canditate_info.Add(canditate_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.edu_dtl = new SelectList(db.Edu_tbl, "Id", "Id", canditate_info.edu_dtl);
            ViewBag.work_exp = new SelectList(db.work_tbl, "Id", "Id", canditate_info.work_exp);
            return View(canditate_info);
        }

        // GET: Canditate_info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canditate_info canditate_info = db.Canditate_info.Find(id);
            if (canditate_info == null)
            {
                return HttpNotFound();
            }
            ViewBag.edu_dtl = new SelectList(db.Edu_tbl, "Id", "Id", canditate_info.edu_dtl);
            ViewBag.work_exp = new SelectList(db.work_tbl, "Id", "Id", canditate_info.work_exp);
            return View(canditate_info);
        }

        // POST: Canditate_info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Cell_no,DOB,Gender,Password,CNIC,edu_dtl,work_exp")] Canditate_info canditate_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(canditate_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.edu_dtl = new SelectList(db.Edu_tbl, "Id", "Id", canditate_info.edu_dtl);
            ViewBag.work_exp = new SelectList(db.work_tbl, "Id", "Id", canditate_info.work_exp);
            return View(canditate_info);
        }

        // GET: Canditate_info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canditate_info canditate_info = db.Canditate_info.Find(id);
            if (canditate_info == null)
            {
                return HttpNotFound();
            }
            return View(canditate_info);
        }

        // POST: Canditate_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Canditate_info canditate_info = db.Canditate_info.Find(id);
            db.Canditate_info.Remove(canditate_info);
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
