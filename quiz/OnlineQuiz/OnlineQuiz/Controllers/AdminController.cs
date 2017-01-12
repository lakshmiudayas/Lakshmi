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
    public class AdminController : Controller
    {
        private AdminData db = new AdminData();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            List<Admin> listOfadmin = db.admin.ToList();
            return View(listOfadmin);
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            Admin admin = db.admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.admin.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Admin admin = db.admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Admin admin = db.admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.admin.Find(id);
            db.admin.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}