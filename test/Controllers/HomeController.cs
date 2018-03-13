using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Database;

namespace test.Controllers
{
    public class HomeController : Controller
    {
    
        public ActionResult Index()
        {
            DataClasses1DataContext dataContext = new DataClasses1DataContext();
            var q =
                from cust in dataContext.Persons
                select cust;
            Console.WriteLine("people with a name: ");
            Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            foreach (var z in q)
            {
                Console.WriteLine("\t {0}", z.surname);
            }


            Console.WriteLine();
            ViewBag.Message = "Login";
            return View();
         
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}