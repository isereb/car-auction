using System.Web.Mvc;
using CarAuction2.Models.User;
using CarAuction2.Security;

namespace CarAuction2.Controllers
{
    [AuthFilter]
    public class PanelController : Controller
    {
        // GET
        public ActionResult Index()
        {
            ViewBag.Username = ((User) Session["User"]).Email;
            return View();
        }
    }
}