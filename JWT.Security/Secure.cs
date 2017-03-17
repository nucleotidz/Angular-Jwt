using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWT.Security
{
    public class Secure : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {          

            if (filterContext.HttpContext.Session["x-session"] == null)
                filterContext.Result = new RedirectResult("~/Security/Login");
        }
    }
}