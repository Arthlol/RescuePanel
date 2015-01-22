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
    public class RescuerController : Controller
    {
        private RescueEntities db = new RescueEntities();

        //
        // GET: /Rescuer/

        public ActionResult Index()
        {
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            var rescuer = db.Rescuer.Include(r => r.EmergencyTeam).Include(r => r.Employee);
            return View(rescuer.ToList());
        }

        //
        // GET: /Rescuer/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            Rescuer rescuer = db.Rescuer.Find(id);
            if (rescuer == null)
            {
                return HttpNotFound();
            }
            return View(rescuer);
        }

        //
        // GET: /Rescuer/Create

        public ActionResult Create()
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            ViewBag.EmergencyTeamId = new SelectList(db.EmergencyTeam, "EmergencyTeamId", "EmergencyTeamName");
            ViewBag.UserId = new SelectList(db.Employee.Where(e => e.Rescuer == null && e.Operator == null && e.Driver == null), "UserId", "UserId");
            return View();
        }

        //
        // POST: /Rescuer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rescuer rescuer)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            if (ModelState.IsValid)
            {
                db.Rescuer.Add(rescuer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmergencyTeamId = new SelectList(db.EmergencyTeam, "EmergencyTeamId", "EmergencyTeamId", rescuer.EmergencyTeamId);
            ViewBag.UserId = new SelectList(db.Employee, "UserId", "WorkPhone", rescuer.UserId);
            return View(rescuer);
        }

        //
        // GET: /Rescuer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!(Roles.IsUserInRole("Administrator") || WebSecurity.CurrentUserId == id))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            Rescuer rescuer = db.Rescuer.Find(id);
            if (rescuer == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmergencyTeamId = new SelectList(db.EmergencyTeam, "EmergencyTeamId", "EmergencyTeamId", rescuer.EmergencyTeamId);
            ViewBag.UserId = new SelectList(db.Employee, "UserId", "WorkPhone", rescuer.UserId);
            return View(rescuer);
        }

        //
        // POST: /Rescuer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Rescuer rescuer)
        {
            if (!(Roles.IsUserInRole("Administrator") || WebSecurity.CurrentUserId == rescuer.UserId))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            if (ModelState.IsValid)
            {
                db.Entry(rescuer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmergencyTeamId = new SelectList(db.EmergencyTeam, "EmergencyTeamId", "EmergencyTeamId", rescuer.EmergencyTeamId);
            ViewBag.UserId = new SelectList(db.Employee, "UserId", "WorkPhone", rescuer.UserId);
            return View(rescuer);
        }

        //
        // GET: /Rescuer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            Rescuer rescuer = db.Rescuer.Find(id);
            if (rescuer == null)
            {
                return HttpNotFound();
            }
            return View(rescuer);
        }

        //
        // POST: /Rescuer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            Rescuer rescuer = db.Rescuer.Find(id);
            db.Rescuer.Remove(rescuer);
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