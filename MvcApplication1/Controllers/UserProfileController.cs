using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Web.Security;

namespace MvcApplication1.Controllers
{
    public class UserProfileController : Controller
    {
        private RescueEntities db = new RescueEntities();

        //
        // GET: /UserProfile/

        public ActionResult Index()
        {
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            var userprofile = db.UserProfile.Include(u => u.UserInformation);
            return View(userprofile.ToList());
        }

        //
        // GET: /UserProfile/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            UserProfile userprofile = db.UserProfile.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // GET: /UserProfile/Create

        public ActionResult Create()
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            ViewBag.UserId = new SelectList(db.UserInformation, "UserId", "LastName");
            return View();
        }

        //
        // POST: /UserProfile/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserProfile userprofile)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            if (ModelState.IsValid)
            {
                db.UserProfile.Add(userprofile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserInformation, "UserId", "LastName", userprofile.UserId);
            return View(userprofile);
        }

        //
        // GET: /UserProfile/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            UserProfile userprofile = db.UserProfile.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserInformation, "UserId", "LastName", userprofile.UserId);
            return View(userprofile);
        }

        //
        // POST: /UserProfile/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserProfile userprofile)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            if (ModelState.IsValid)
            {
                db.Entry(userprofile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserInformation, "UserId", "LastName", userprofile.UserId);
            return View(userprofile);
        }

        //
        // GET: /UserProfile/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            UserProfile userprofile = db.UserProfile.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /UserProfile/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            UserProfile userprofile = db.UserProfile.Find(id);
            db.UserProfile.Remove(userprofile);
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