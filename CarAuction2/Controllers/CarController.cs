using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CarAuction2.App_Data;
using CarAuction2.Models.Car;
using CarAuction2.Models.User;
using CarAuction2.Security;

namespace CarAuction2.Controllers
{
    [AuthFilter]
    public class CarController : Controller
    {
        private static readonly CarAuctionContext Ctx = new CarAuctionContext();

        public JsonResult GetAll()
        {
            return Json(Ctx.Cars.Select(x => x).ToList());
        }

        [HttpGet]
        public ActionResult MyCars()
        {
            ViewBag.MyCars = Ctx.Cars.ToList().Where(c => c.SellerId == ((User) Session["User"]).UserId);
            return View();
        }

        [HttpGet]
        public ActionResult Publish()
        {
            ViewBag.Marks = Ctx.Marks.ToList();
            ViewBag.Models = Ctx.Models.ToList();
            return View();
        }

        [HttpPost]
        public JsonResult Publish(Car car)
        {
            try
            {
                car.SellerId = ((User) HttpContext.Session["User"]).UserId;
                Ctx.Cars.Add(car);
                Ctx.SaveChanges();
                return Json(true);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

        [HttpGet]
        public JsonResult GetModels(int id = 0)
        {
            if (id == 0)
                return Json(Ctx.Marks.ToList().Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.MarkId.ToString()
                    }
                ), JsonRequestBehavior.AllowGet);
            IEnumerable<Model> models =
                from c in Ctx.Models
                where c.MarkId == id
                select c;
            return Json(models.Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.ModelId.ToString()
                }
            ), JsonRequestBehavior.AllowGet);
        }
    } 
}