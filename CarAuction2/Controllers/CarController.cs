using System;
using System.Linq;
using System.Web.Mvc;
using CarAuction2.App_Data;
using CarAuction2.Models.Car;

namespace CarAuction2.Controllers
{
    public class CarController : Controller
    {
        public JsonResult GetAll()
        {
            using (var ctx = new CarAuctionContext())
            {
                return Json(ctx.Cars.Select(x => x).ToList());
            }
        }

        [HttpGet]

        public ActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult Add(Car car)
        {
            using (var ctx = new CarAuctionContext())
            {
                try
                {
                    ctx.Cars.Add(car);
                    ctx.SaveChanges();  
                    return Json(true);
                } catch(Exception e)
                {
                    return Json(false);
                }
            }
        }
    }
}