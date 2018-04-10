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
            var persons = (from m in dataContext.Users
                         select m);
   
            return View(persons);
            //return View();
        }
        public ActionResult Edit(int id)
        {
            var dataContext = new UserDataContext();
            var query = (from m in dataContext.Users
                         where m.Id == id
                         select m );
            User user = query.First();
            return View(user);
        }
        [HttpPost]
        public ActionResult Save(User u)
        {
            var dataContext = new UserDataContext();
         
            return View("../Home/Index");
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}