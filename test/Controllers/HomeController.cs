using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        DbWrapper dataBase = new DbWrapper();
        public ActionResult Index()
        {
            return View(dataBase.getUsers());
        }
        public ActionResult HomePage()
        {
            

            return View();

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ActionName("Create")]
        public ActionResult Save(User user)
        {
            dataBase.addUser(user);
            return RedirectToAction("Index");
        }
        public  ActionResult Edit(int? id)
        {
            ViewBag.Message = "Edit selected user ";
            User user = dataBase.getUserById(id);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id,User user )
        {
            dataBase.updateUser(id, user);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(String username, String password)
        {
            var users = dataBase.getUsers();

            foreach (User person in users)
            {
                if(person.username.Trim().Equals(username) && person.password.Trim().Equals(password))
                {
                    //ViewBag.Title = "Good Work Mr. " + person.name;
                    return View("../Home/Success");
                }
            }
            return View("../Home/TryAgain");
        }

        public ActionResult Success()
        {
            ViewBag.Message = "Bravo";

            return View();

        }

        public ActionResult Delete(int? id)
        {
            User user = dataBase.getUserById(id);
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {
            dataBase.deleteUserById(id);
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}