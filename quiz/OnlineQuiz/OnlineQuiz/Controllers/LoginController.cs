using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineQuiz.Models;

namespace OnlineQuiz.Controllers
{
    public class LoginController : Controller
    {
        private LoginEntities db = new LoginEntities();
        public ActionResult Login(Login login)
        {
            string user = string.Empty;
            Login matchedLogin = db.login.
                Where(each => each.Username.Equals(login.Username) && each.Password.Equals(login.Password)).
                FirstOrDefault();

            if (matchedLogin.Isadmin.Equals(true))
            {
                user = "Admin";
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                user = "Student";
                return RedirectToAction("GetQuestions", "User");
            }
        }

        public ActionResult LoginIndex(Login login)
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View("Endpage");
        }
    }
}

