using GYM.Models.Session;
using System.Web;
using System.Web.Mvc;

namespace GYM.Attributes
{
    public class SessionAuth : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // return httpContext.Session["App"] != null;
            //adding
            if (AppSession.Session == null)
            {
                return AppSession.Session != null;
            }
            else
            {
                return AppSession.Session.SessionRepo != null;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            HttpContext context = HttpContext.Current;
            string baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority +
            context.Request.ApplicationPath.TrimEnd('/') + "/UnAuthorized";
            filterContext.Result = new RedirectResult(baseUrl);
        }
    }
}