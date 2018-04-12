using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Admin()
        {
            try
            {
                using (UserContext db = new UserContext())
                {
                    IEnumerable<User> users = db.Users.ToList();
                    ViewBag.UserInfo = users;
                    return View();
                }
                 
            }
            catch (Exception ex)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit_User(string action,int Id)
        {
            if (action == "Delete")
            {
                using(UserContext db=new UserContext())
                {
                    User u = db.Users.Find(Id);
                    if (u != null)
                    {
                        db.Users.Remove(u);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Admin", "Admin");
                }
               
            }
            return View();
        }
    }
}