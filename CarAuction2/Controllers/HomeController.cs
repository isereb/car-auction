using System.Web.Mvc;

namespace CarAuction2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About us";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us";
            return View();
        }
    }
}