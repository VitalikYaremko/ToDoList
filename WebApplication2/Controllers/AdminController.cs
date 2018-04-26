using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using WebApplication2.Models;
using Microsoft.AspNet.Identity.Owin;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        UserContext db = new UserContext();

        public ActionResult Admin()
        {
            var UserLogin = User.Identity.Name;
            ViewBag.UserLogin = UserLogin;
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult ViewAdmin()
        {
            try
            {
                IEnumerable<User> users = db.Users.ToList();
                ViewBag.UserInfo = users;
                return View();
            }
            catch (Exception ex)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult EditUser(string product, string action, int Id)
        {
            if (action == "Edit")
            {
                return RedirectToAction("UpdateUser", "Admin",new { @Id=Id});
            }
            if (action == "Delete")
            {
                User u = db.Users.Find(Id);
                if (u != null)
                {
                    db.Users.Remove(u);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAdmin", "Admin");
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult UpdateUser(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            User user = db.Users.Find(Id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ViewAdmin", "Admin");
        }
    }
}