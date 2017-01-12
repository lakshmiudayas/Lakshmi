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
    public class UserController : Controller
    {
        private UserData db = new UserData();
        private AdminData admin = new AdminData();
        Random random = new Random();

        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(db.user.ToList());
        }
        List<Admin> questionList = new List<Admin>();
        int currentIndex = 0;

        public ActionResult GetQuestions()
        {
            List<Admin> listOfAdmin = admin.admin.ToList();
            if (currentIndex == 5)
            {
                return HttpNotFound();
            }
            for (int choice = 0; choice < 5; choice++)
            {
                int randomchoice = random.Next(listOfAdmin.Count);
                questionList.Add(listOfAdmin[randomchoice]);
            }
            Admin disp = Display();
            return View(Submit(disp));
        }
        
        public Admin Display()
        {
            Admin question = new Admin();
            if (currentIndex < 5)
            {
                question = questionList[currentIndex];
            }
            currentIndex++;
            return question;
        }

        public Admin Submit(Admin quest)
        {
            List<string> optionList = new List<string>();
            optionList.Add(quest.Option1);
            optionList.Add(quest.Option2);
            optionList.Add(quest.Option3);
            optionList.Add(quest.Option4);
            quest.OptionList = optionList;
            quest.SelectedAnswer = "";
            if (ModelState.IsValid)
                    {
                        String SelectedAnswer = quest.SelectedAnswer;
                    }
        
            return quest;
        }

        [HttpGet]
        public ActionResult EDIT(Admin quest)
        {
            quest.SelectedAnswer = Convert.ToString(quest.ID);
            return View(quest);
        }
        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
        {
            User user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View("OnlineTest");
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.user.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.user.Find(id);
            db.user.Remove(user);
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