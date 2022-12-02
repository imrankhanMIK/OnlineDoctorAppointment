using online_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace online_test.Controllers
{
    public class AdminController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();
      
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(String email ,String password)
        {
            var login_data = from d in db.Manager_info where d.Email == email select d;

            if (email == login_data.First().Email && password == login_data.First().Pasword)
            {
                Session["admin_doctor_id"] = login_data.First().Id;
                return RedirectToAction("dashboard");
            }
            else
            {
                ViewBag.Error = "Login Failed";
                return View();
            }

        }
        public ActionResult dashboard()
        {
            return View();
        }
    }
}