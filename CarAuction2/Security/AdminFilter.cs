using System.Web.Mvc;
using System.Web.Routing;
using CarAuction2.Models.User;

namespace CarAuction2.Security
{
    public class AdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["User"] == null ||
                !((User) filterContext.HttpContext.Session["User"]).IsInRole(2))
            {
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "Index");
                redirectTargetDictionary.Add("controller", "Panel");
                redirectTargetDictionary.Add("area", "");
                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }
        }
    }
}