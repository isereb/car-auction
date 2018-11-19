using System;
using System.Linq;
using System.Web.Mvc;
using CarAuction2.App_Data;
using CarAuction2.Models.User;

namespace CarAuction2.Controllers
{
    public class SignController : Controller
    {
        [HttpGet]
        public ActionResult In()
        {
            if (Session["user"] != null)
            {
                Response.Redirect("/Panel");
            }

            AuthAttempt authAttempt = new AuthAttempt();
            return View(authAttempt);
        }

        [HttpPost]
        [ActionName("In")]
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

        [HttpGet]
        public ActionResult Up()
        {
            ViewBag.Title = "Sign up";
            User user = new User();
            return View(user);
        }

        [HttpPost]
        [ActionName("Up")]
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

        [HttpGet]
        public ActionResult Out()
        {
            Session["User"] = null;
            Response.Redirect("/Sign/In");
            return null;
        }
    }
}