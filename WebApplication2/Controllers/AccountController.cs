using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)// після введення користувачем даних, вони будуть передані сюда у вигляді обєкта логінмодел
        {
            if (ModelState.IsValid)
            {
                // serch user for bd
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Name && u.Password == model.Password);

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                   
                    return RedirectToAction("Main", "Main");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password");
                }
            }
            
            return View(model);
        }


        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)// тут RegisterModel model який передає дані
        {
            if (ModelState.IsValid)//перевіряємо модель на коректність
            {
                User user = null;
                using(UserContext db = new UserContext())//звертаємось до контексту даних
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Name);//шукаємо користувача по логіну
                }
                if(user == null)//якщо не знайшли користувача тоді створюєм нового
                {
                    using(UserContext db = new UserContext())
                    {   //           ств обєкт Юзер по даних які передані через RegisterModel model
                        db.Users.Add(new User { Email = model.Name, Password = model.Password, Age = model.Age });
                        db.SaveChanges();
                        user = db.Users.Where(u => u.Email == model.Name && u.Password == model.Password).FirstOrDefault();
                        //
                    }
                    if(user != null)
                    {
                        
                        FormsAuthentication.SetAuthCookie(model.Name, true);// 1 параметр логін користувача , 2 чи будуть зберігати на довгий час регістраційні кукі
                        return RedirectToAction("Main", "Main");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User with such login already exists");
                }
            }
            return View(model);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Main", "Main");
        }
    }
}