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
        public ActionResult Index()
        {
            var dataContext = new UserDataContext();
            var users = (from m in dataContext.Users
                         select m);
   
            return View(users);
    
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ActionName("Create")]
        public ActionResult Save(User user)
        {
            var dataContext = new UserDataContext();
            dataContext.Users.InsertOnSubmit(user);
            dataContext.SubmitChanges();
            return RedirectToAction("Index");
        }
        public  ActionResult Edit(int? id)
        {
            ViewBag.Message = "Edit selected user ";
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var dataContext = new UserDataContext();
                var query = (from m in dataContext.Users
                             where m.Id == id
                             select m);
                User user = query.First();
                if(user == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(user);
                }
            }
         
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id,User user )
        {
            var dataContext = new UserDataContext();
            var query = (from m in dataContext.Users
                        where m.Id == id
                        select m);
            query.First().Id = user.Id;
            query.First().person_id = user.person_id;
            query.First().username = user.username;
            query.First().password = user.password;
            query.First().type = user.type;
            dataContext.SubmitChanges();
            ViewBag.Message = "Field saved in the database";
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
            Console.WriteLine(username);
            var dataContext = new UserDataContext();
            var users = (from m in dataContext.Users
                           select m);

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
            var dataContext = new UserDataContext();
            var query = (from m in dataContext.Users
                         where m.Id == id
                         select m);
            User user = query.First();
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {
            var dataContext = new UserDataContext();
            var query = (from m in dataContext.Users
                         where m.Id == id
                         select m);
            dataContext.Users.DeleteOnSubmit(query.First());
            dataContext.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}