﻿using System;
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
            var dataContext = new PersonDataContext();
            var persons = (from m in dataContext.Persons
                         select m);
   
            return View(persons);
            //return View();
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
            var dataContext = new PersonDataContext();
            var persons = (from m in dataContext.Persons
                           select m);

            foreach (Person person in persons)
            {

                if(person.username.Trim().Equals(username) && person.password.Trim().Equals(password))
                {
                    ViewBag.Title = "Good Work Mr. " + person.name;
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