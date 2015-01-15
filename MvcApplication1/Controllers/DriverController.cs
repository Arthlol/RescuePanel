using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class DriverController : Controller
    {
        private RescueEntities db = new RescueEntities();

        //
        // GET: /Driver/

        public ActionResult Index()
        {
            var driver = db.Driver.Include(d => d.EmergencyTeam).Include(d => d.Employee);
            return View(driver.ToList());
        }

        //
        // GET: /Driver/Details/5

        public ActionResult Details(int id = 0)
        {
            Driver driver = db.Driver.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        //
        // GET: /Driver/Create

        public ActionResult Create()
        {
            ViewBag.EmergencyTeamId = new SelectList(db.EmergencyTeam, "EmergencyTeamId", "EmergencyTeamId");
            ViewBag.UserId = new SelectList(db.Employee, "UserId", "WorkPhone");
            return View();
        }

        //
        // POST: /Driver/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Driver.Add(driver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmergencyTeamId = new SelectList(db.EmergencyTeam, "EmergencyTeamId", "EmergencyTeamId", driver.EmergencyTeamId);
            ViewBag.UserId = new SelectList(db.Employee, "UserId", "WorkPhone", driver.UserId);
            return View(driver);
        }

        //
        // GET: /Driver/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Driver driver = db.Driver.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmergencyTeamId = new SelectList(db.EmergencyTeam, "EmergencyTeamId", "EmergencyTeamId", driver.EmergencyTeamId);
            ViewBag.UserId = new SelectList(db.Employee, "UserId", "WorkPhone", driver.UserId);
            return View(driver);
        }

        //
        // POST: /Driver/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmergencyTeamId = new SelectList(db.EmergencyTeam, "EmergencyTeamId", "EmergencyTeamId", driver.EmergencyTeamId);
            ViewBag.UserId = new SelectList(db.Employee, "UserId", "WorkPhone", driver.UserId);
            return View(driver);
        }

        //
        // GET: /Driver/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Driver driver = db.Driver.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        //
        // POST: /Driver/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Driver driver = db.Driver.Find(id);
            db.Driver.Remove(driver);
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