using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace WebApplication2.Infrastructure
{
    public static class IdentityHelpers // this helper return is UserName
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            AppUserManager mrg = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();

            return new MvcHtmlString(mrg.FindByIdAsync(id).Result.UserName);
        }
    }
}