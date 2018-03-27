using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ListController : Controller
    {
        ListContext db = new ListContext();
        // GET: List
        [Authorize]
        public ActionResult List()
        {
            return View();
        }
        [Authorize]
        public ActionResult ViewList()
        {
            var CurUser = User.Identity.Name;
            IEnumerable<List> lists = db.Lists;
            var filtered = lists.Where(p => p.Name == CurUser);
            ViewBag.Lists = filtered;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult List(ListModel model)
        {

            if (ModelState.IsValid)
            {
                var CurUser = User.Identity.Name;
                using (ListContext db = new ListContext())
                {
                    db.Lists.Add(new List { Name = CurUser, NameList = model.NameList, Description = model.Description, Date = model.Date });
                    db.SaveChanges();

                    return RedirectToAction("ViewList", "List");
                }

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditList(string product, string action, int Id)
        {
            if (action == "Edit")
            {
               return RedirectToAction("UpdateList", "List", new { @Id = Id });
            }
            if (action == "Delete")
            {
                List l = db.Lists.Find(Id);
                if (l != null)
                {
                    db.Lists.Remove(l);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewList", "List");
            }
            return HttpNotFound();
        }
        [HttpGet]
        public ActionResult UpdateList(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            List list = db.Lists.Find(Id);

            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult UpdateList(List list)
        {
            db.Entry(list).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ViewList", "List");
        }
    }
}