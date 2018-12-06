using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using CarAuction2.App_Data;
using CarAuction2.Models.Car;
using CarAuction2.Models.User;
using CarAuction2.Security;

namespace CarAuction2.Controllers
{
    [AuthFilter]
    public class PanelController : Controller
    {
        private static readonly CarAuctionContext Ctx = new CarAuctionContext();
        
        // This controller created for handling statistic page
        // Have to be made last
        // TODO Do statistics page at /Panel
        public ActionResult Index()
        {
            ViewBag.FirstName = (Session["User"] as User)?.FirstName;
            return View();
        }

        public ActionResult MyProfile()
        {
            ViewBag.User = Session["User"];
            return View();
        }
        
        
        // Admin features below this point
        
        [AdminFilter]
        [HttpGet]
        public ActionResult AddMark()
        {
            return View();
        }

        [AdminFilter]
        [HttpGet]
        public ActionResult AllMarks()
        {
            ViewBag.AllMarks = Ctx.Marks.ToList();
            return View();
        }
        
        [AdminFilter]
        [HttpGet]
        public ActionResult ModelsByMark(int id = 0)
        {
            Mark mark = Ctx.Marks.Find(id);
            if (mark != null)
            {
                ViewBag.Mark = mark;
                ViewBag.ModelsByMark = Ctx.Models.ToList().Where(model => model.MarkId == id).ToList(); 
                return View();   
            }
            return View("AllMarks");
        }

        [AdminFilter]
        [HttpGet]
        public JsonResult DeleteMark(Mark mark)
        {
            try
            {
                Ctx.Marks.Remove(Ctx.Marks.Find(mark.MarkId) ?? throw new IOException("Wrong Id"));
                Ctx.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        
        [AdminFilter]
        [HttpGet]
        public JsonResult DeleteModel(Model model)
        {
            try
            {
                Ctx.Models.Remove(Ctx.Models.Find(model.MarkId) ?? throw new IOException("Wrong Id"));
                Ctx.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        
        [AdminFilter]
        [HttpPost]
        public JsonResult AddMark(Mark mark)
        {
            try
            {
                Ctx.Marks.Add(mark);
                Ctx.SaveChanges();
                return Json(true);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }
        
        [AdminFilter]
        [HttpGet]
        public ActionResult AddModel()
        {
            ViewBag.Marks = Ctx.Marks.ToList();
            return View();
        }
        
        [AdminFilter]
        [HttpPost]
        public JsonResult AddModel(Model model)
        {
            try
            {
                Ctx.Models.Add(model);
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