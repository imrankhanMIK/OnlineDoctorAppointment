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
    public class Question_bankController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Question_bank
        public ActionResult Index()
        {
            var question_bank = db.Question_bank.Include(q => q.Course_tbl);
            return View(question_bank.ToList());
        }


        public ActionResult General_knowledge()
        {
            var question_bank = from d in db.Question_bank where d.Course_id == 1 select d;
            if (Session["Rem_Time"] == null)
            {
                Session["Rem_Time"] = DateTime.Now.AddMinutes(5).ToString("dd-MM-yyyy h:mm:ss tt");
            }
            ViewBag.Rem_Time = Session["Rem_Time"];



            return View(question_bank.ToList());

        }
        public ActionResult Maths()
        {
            var question_bank = from d in db.Question_bank where d.Course_id == 2 select d;

            if (Session["Rem_Time"] == null)
            {
                Session["Rem_Time"] = DateTime.Now.AddMinutes(5).ToString("dd-MM-yyyy h:mm:ss tt");
            }
            ViewBag.Rem_Time = Session["Rem_Time"];
            return View(question_bank.ToList());
        }
        public ActionResult Computer_technology()
        {
            var question_bank = from d in db.Question_bank where d.Course_id == 3 select d;

            if (Session["Rem_Time"] == null)
            {
                Session["Rem_Time"] = DateTime.Now.AddMinutes(5).ToString("dd-MM-yyyy h:mm:ss tt");
            }
            ViewBag.Rem_Time = Session["Rem_Time"];
            return View(question_bank.ToList());
        }
        // GET: Question_bank/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_bank question_bank = db.Question_bank.Find(id);
            if (question_bank == null)
            {
                return HttpNotFound();
            }
            return View(question_bank);
        }

        // GET: Question_bank/Create
        public ActionResult Create()
        {
            ViewBag.Course_id = new SelectList(db.Course_tbl, "Id", "name");
            return View();
        }

        // POST: Question_bank/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Question,Answer,Option_1,Option_2,Option_3,C_Option_4,Course_id")] Question_bank question_bank)
        {
            if (ModelState.IsValid)
            {
                db.Question_bank.Add(question_bank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_id = new SelectList(db.Course_tbl, "Id", "name", question_bank.Course_id);
            return View(question_bank);
        }

        // GET: Question_bank/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_bank question_bank = db.Question_bank.Find(id);
            if (question_bank == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_id = new SelectList(db.Course_tbl, "Id", "name", question_bank.Course_id);
            return View(question_bank);
        }

        // POST: Question_bank/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Question,Answer,Option_1,Option_2,Option_3,C_Option_4,Course_id")] Question_bank question_bank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question_bank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_id = new SelectList(db.Course_tbl, "Id", "name", question_bank.Course_id);
            return View(question_bank);
        }

        // GET: Question_bank/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question_bank question_bank = db.Question_bank.Find(id);
            if (question_bank == null)
            {
                return HttpNotFound();
            }
            return View(question_bank);
        }

        // POST: Question_bank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question_bank question_bank = db.Question_bank.Find(id);
            db.Question_bank.Remove(question_bank);
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

