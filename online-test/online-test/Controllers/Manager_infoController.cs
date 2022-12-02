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
    public class Manager_infoController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Manager_info
        public ActionResult Index()
        {
            return View(db.Manager_info.ToList());
        }

        // GET: Manager_info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager_info manager_info = db.Manager_info.Find(id);
            if (manager_info == null)
            {
                return HttpNotFound();
            }
            return View(manager_info);
        }

        // GET: Manager_info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager_info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Pasword,Cell_no,Gender")] Manager_info manager_info)
        {
            if (ModelState.IsValid)
            {
                db.Manager_info.Add(manager_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manager_info);
        }

        // GET: Manager_info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager_info manager_info = db.Manager_info.Find(id);
            if (manager_info == null)
            {
                return HttpNotFound();
            }
            return View(manager_info);
        }

        // POST: Manager_info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Pasword,Cell_no,Gender")] Manager_info manager_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manager_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manager_info);
        }

        // GET: Manager_info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager_info manager_info = db.Manager_info.Find(id);
            if (manager_info == null)
            {
                return HttpNotFound();
            }
            return View(manager_info);
        }

        // POST: Manager_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manager_info manager_info = db.Manager_info.Find(id);
            db.Manager_info.Remove(manager_info);
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
