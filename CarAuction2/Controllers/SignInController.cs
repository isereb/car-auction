using System;
using System.Linq;
using System.Web.Mvc;
using CarAuction2.App_Data;
using CarAuction2.Models.User;

namespace CarAuction2.Controllers
{
    public class SignInController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                Response.Redirect("/Panel");
            }

            AuthAttempt authAttempt = new AuthAttempt();
            return View(authAttempt);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult SignInHandler(AuthAttempt authAttempt)
        {
            if (ModelState.IsValid)
            {
                // check if the credentials are right
                // and store user in session
                using (var ctx = new CarAuctionContext())
                {
                    try
                    {
                        User existingUser = ctx.Users.FirstOrDefault(
                            u => u.Email == authAttempt.Email && u.Password == authAttempt.Password
                        );
                        if (existingUser != null)
                        {
                            HttpContext.Session["User"] = existingUser;
                            Console.Out.WriteLine(HttpContext.Session["User"]);
                            Response.Redirect("/Panel");
                            return null;
                        }
                    }
                    catch (InvalidOperationException ignored)
                    {
                    }
                }
            }

            ViewBag.FailureMessage = "Incorrect email or password";
            return View();
        }
    }
}