using System;
using System.Linq;
using System.Web.Mvc;
using CarAuction2.App_Data;
using CarAuction2.Models.Car;

namespace CarAuction2.Controllers
{
    public class CarController : Controller
    {
        private static readonly CarAuctionContext Ctx = new CarAuctionContext();

        public JsonResult GetAll()
        {
            return Json(Ctx.Cars.Select(x => x).ToList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Marks = Ctx.Marks.ToList();
            ViewBag.Models = Ctx.Models.ToList();
            return View();
        }

        [HttpPost]
        public JsonResult Add(Car car)
        {
            try
            {
                Ctx.Cars.Add(car);
                Ctx.SaveChanges();
                return Json(true);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }
    }
}