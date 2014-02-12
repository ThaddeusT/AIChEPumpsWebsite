using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PumpsProjectWebsite.Helpers
{
    public class OptionalAuthorize : AuthorizeAttribute
    {

        public bool Authorize { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (Authorize == true)
            {
                return base.AuthorizeCore(httpContext);
            }

            return true;
        }

        public OptionalAuthorize()
            : base()
        {
            Authorize = true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new
            RouteValueDictionary(new { controller = "Home", action = "Index", area = "" }));
        }

    }
}
