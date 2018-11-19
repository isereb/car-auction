using System;
using System.Web.Mvc;

namespace CarAuction2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Console.Out.WriteLine(HttpContext.Session["User"]);
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