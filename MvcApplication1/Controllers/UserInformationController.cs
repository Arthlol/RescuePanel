using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Web.Security;
using WebMatrix.WebData;

namespace MvcApplication1.Controllers
{
    public class UserInformationController : Controller
    {
        private RescueEntities db = new RescueEntities();

        //
        // GET: /UserInformation/

        public ActionResult Index()
        {
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            return View(db.UserInformation.ToList());
        }

        //
        // GET: /UserInformation/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            UserInformation userinformation = db.UserInformation.Find(id);
            if (userinformation == null)
            {
                return HttpNotFound();
            }
            return View(userinformation);
        }

        //
        // GET: /UserInformation/Create

        public ActionResult Create()
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            return View();
        }

        //
        // POST: /UserInformation/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserInformation userinformation)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            if (ModelState.IsValid)
            {
                db.UserInformation.Add(userinformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userinformation);
        }

        //
        // GET: /UserInformation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!(Roles.IsUserInRole("Administrator") || WebSecurity.CurrentUserId == id))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            UserInformation userinformation = db.UserInformation.Find(id);
            if (userinformation == null)
            {
                return HttpNotFound();
            }
            return View(userinformation);
        }

        //
        // POST: /UserInformation/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserInformation userinformation)
        {
            if (!(Roles.IsUserInRole("Administrator") || WebSecurity.CurrentUserId == userinformation.UserId))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            if (ModelState.IsValid)
            {
                db.Entry(userinformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userinformation);
        }

        //
        // GET: /UserInformation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            UserInformation userinformation = db.UserInformation.Find(id);
            if (userinformation == null)
            {
                return HttpNotFound();
            }
            return View(userinformation);
        }

        //
        // POST: /UserInformation/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            UserInformation userinformation = db.UserInformation.Find(id);
            db.UserInformation.Remove(userinformation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}