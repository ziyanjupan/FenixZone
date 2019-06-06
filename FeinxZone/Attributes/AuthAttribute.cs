using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeinxZone.Attributes
{
    public class AuthAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (IsAnonymousAction(filterContext)) {
                return;
            }

            if (filterContext.HttpContext.Session["currentUserId"] == null) {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        {"controller","Login" },
                        {"action","Index" }
                    });
            }
        }

        private bool IsAnonymousAction(AuthorizationContext authorizationContext)
        {
            return authorizationContext.ActionDescriptor
                                       .GetCustomAttributes(inherit: true)
                                       .OfType<AllowAnonymousAttribute>()
                                       .Any();
        }
    }
}