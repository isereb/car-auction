using System.Web.Mvc;
using System.Web.Routing;
using CarAuction2.App_Data;

namespace CarAuction2.Security
{
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["User"] == null)
            {
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "Index");
                redirectTargetDictionary.Add("controller", "SignIn");
                redirectTargetDictionary.Add("area", "");
                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }
        }

    }
}