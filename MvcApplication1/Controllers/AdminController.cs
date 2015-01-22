using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using WebMatrix.WebData;
using System.Web.Security;
using System.Data.SqlClient;
using MvcApplication1.Filters;
namespace MvcApplication1.Controllers
{
    public class AdminController : Controller
    {
        private RescueEntities db = new RescueEntities();

        //
        // GET: /Admin/
        [InitializeSimpleMembership]
        public ActionResult Index()
        {
            
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }

                var administrator = db.Administrator.Include(a => a.UserInformation);
                return View(administrator.ToList());
        }

        //
        // GET: /Admin/Details/5
        [InitializeSimpleMembership]
        public ActionResult Details(int id = 0)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }

            Administrator administrator = db.Administrator.Find(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            return View(administrator);
        }

        //
        // GET: /Admin/Create
        [InitializeSimpleMembership]
        public ActionResult Create()
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }

            ViewBag.UserId = new SelectList(db.UserInformation.Where(x => x.Administrator == null && x.Employee == null), "UserId", "UserId");
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [InitializeSimpleMembership]
        public ActionResult Create(Administrator administrator)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            if (ModelState.IsValid)
            {
                if (db.Administrator.Where(x => x.UserId == administrator.UserId).Count() == 0)
                {
                    db.Administrator.Add(administrator);
                    db.SaveChanges();
                    administrator.UserInformation = db.UserInformation.First(x => x.UserId == administrator.UserId);
                    db.SaveChanges();
                    administrator.UserInformation.UserProfile = db.UserProfile.First(x => x.UserId == administrator.UserInformation.UserId);
                    db.SaveChanges();
                    Roles.AddUserToRole(administrator.UserInformation.UserProfile.UserName, "Administrator");
                } 
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserInformation, "UserId", "LastName", administrator.UserId);
            return View(administrator);
        }

        //
        // GET: /Admin/Edit/5
        [InitializeSimpleMembership]
        public ActionResult Edit(int id = 0)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            Administrator administrator = db.Administrator.Find(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserInformation, "UserId", "UserId", administrator.UserId);
            return View(administrator);
        }

        //
        // POST: /Admin/Edit/5
        [InitializeSimpleMembership]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Administrator administrator)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            if (ModelState.IsValid)
            {
                db.Entry(administrator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserInformation, "UserId", "LastName", administrator.UserId);
            return View(administrator);
        }

        //
        // GET: /Admin/Delete/5
        [InitializeSimpleMembership]
        public ActionResult Delete(int id = 0)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            Administrator administrator = db.Administrator.Find(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            return View(administrator);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [InitializeSimpleMembership]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            Administrator administrator = db.Administrator.Find(id);
            Roles.RemoveUserFromRole(administrator.UserInformation.UserProfile.UserName, "Administrator");
            db.SaveChanges();
            db.Administrator.Remove(administrator);
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