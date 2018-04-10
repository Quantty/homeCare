using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [ActionName("Login")]
        public void log(String username, String password)
        {
            ViewBag.Message = username;

            Success();
        }

        public ActionResult TryAgain()
        {
            ViewBag.Message = "Nope. That is just wrong";

            return View();
        }
        public ActionResult Success()
        {
            ViewBag.Message = "Bravo";

            return View();
        }
    }
}