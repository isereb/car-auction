using System.Web.Mvc;
using CarAuction2.Models.User;
using CarAuction2.Security;

namespace CarAuction2.Controllers
{
    [AuthFilter]
    public class PanelController : Controller
    {
        // This controller created for handling statistic page
        // Have to be made last
        // TODO Do statistics page at /Panel
        public ActionResult Index()
        {
            ViewBag.FirstName = ((User) Session["User"]).FirstName;
            return View();
        }
    }
}