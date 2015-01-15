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

namespace MvcApplication1.Controllers
{
    public class AdminController : Controller
    {
        private RescueEntities db = new RescueEntities();

        //
        // GET: /Admin/

        public ActionResult Index()
        {

            if (!Roles.IsUserInRole("Administrator"))
            {
                return HttpNotFound();
            }

            else
            {
                var administrator = db.Administrator.Include(a => a.UserInformation);
                return View(administrator.ToList());
            }
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            Administrator administrator = db.Administrator.Find(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            return View(administrator);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserInformation.Where(x => x.Administrator == null && x.Employee == null), "UserId", "UserId");
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                if (db.Administrator.First(x => x.UserId == administrator.UserId) == null)
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

        public ActionResult Edit(int id = 0)
        {
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Administrator administrator)
        {
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

        public ActionResult Delete(int id = 0)
        {
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
        public ActionResult DeleteConfirmed(int id)
        {
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