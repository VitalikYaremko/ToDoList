using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class MainController : Controller
    {
 
        public ActionResult Main()
        {
            var UserLogin = User.Identity.Name;
            ViewBag.UserLogin = UserLogin;
            return View();
        }
    }
}