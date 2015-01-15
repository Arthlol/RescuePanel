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
    public class EmergencyTeamController : Controller
    {
        private RescueEntities db = new RescueEntities();

        //
        // GET: /EmergencyTeam/

        public ActionResult Index()
        {
            return View(db.EmergencyTeam.ToList());
        }

        //
        // GET: /EmergencyTeam/Details/5

        public ActionResult Details(int id = 0)
        {
            EmergencyTeam emergencyteam = db.EmergencyTeam.Find(id);
            if (emergencyteam == null)
            {
                return HttpNotFound();
            }
            return View(emergencyteam);
        }

        //
        // GET: /EmergencyTeam/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EmergencyTeam/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmergencyTeam emergencyteam)
        {
            if (ModelState.IsValid)
            {
                db.EmergencyTeam.Add(emergencyteam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emergencyteam);
        }

        //
        // GET: /EmergencyTeam/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EmergencyTeam emergencyteam = db.EmergencyTeam.Find(id);
            if (emergencyteam == null)
            {
                return HttpNotFound();
            }
            return View(emergencyteam);
        }

        //
        // POST: /EmergencyTeam/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmergencyTeam emergencyteam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emergencyteam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emergencyteam);
        }

        //
        // GET: /EmergencyTeam/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EmergencyTeam emergencyteam = db.EmergencyTeam.Find(id);
            if (emergencyteam == null)
            {
                return HttpNotFound();
            }
            return View(emergencyteam);
        }

        //
        // POST: /EmergencyTeam/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmergencyTeam emergencyteam = db.EmergencyTeam.Find(id);
            db.EmergencyTeam.Remove(emergencyteam);
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