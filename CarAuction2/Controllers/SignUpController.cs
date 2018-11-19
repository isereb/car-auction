using System.Web.Mvc;
using CarAuction2.App_Data;
using CarAuction2.Models.User;

namespace CarAuction2.Controllers
{
    public class SignUpController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Sign up";
            User user = new User();
            return View(user);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult SignUpHandler(User user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.FailureMessage = "Something went wrong";
                return View();
            }
            
            using (var ctx = new CarAuctionContext())
            {
                ctx.Users.Add(user);
                ctx.SaveChanges(); 
            }

            ViewBag.SuccessMessage = "You successfully signed up";
            return View();
        }
        
    }
}