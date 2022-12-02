using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using online_test.Models;

namespace online_test.Controllers
{
    public class HomeController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(string uname , string psw)
        {
            var login_data = from d in db.Manager_info where d.Name == uname select d;

            if (uname == login_data.First().Name && psw == login_data.First().Pasword)
            {
                Session["admin_doctor_id"] = login_data.First().Id;
                return RedirectToAction("home");
            }
            else
            {
                ViewBag.Error = "Login Failed";
                return View();
            }
        }
        public ActionResult home()
        {
            Session["mathexam"] = 1;
            Session["gk_exam"] = 0;
            Session["ct_exam"] = 0;
            return View();
        }

        public ActionResult General_knowledge(int q1,int o1)
        {
            Session["q1"] = "Arctic";
            Session["q2"] = "Japan";
            Session["q3"] = "Kazahistan";
            Session["q4"] = "Canada";
            Session["q5"] = "Paris";

            return View();
        }
        public ActionResult Maths(int q1, int o1)
        {
            Session["q1"] = "3.14";
            Session["q2"] = "26";
            Session["q3"] = "The curved surface area of a clyinder";
            Session["q4"] = "3";
            Session["q5"] = "23";

            return View();
        }
        public ActionResult Computer_technology(int q1, int o1)
        {
            Session["q1"] = "Action";
            Session["q2"] = "Structed Chart";
            Session["q3"] = "Logic flow chart";
            Session["q4"] = "Programmer";
            Session["q5"] = "Governance";

            return View();
        }

        public ActionResult result()
        {
            return View();
        }
    }
}