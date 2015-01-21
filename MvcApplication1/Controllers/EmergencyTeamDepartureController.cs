﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class EmergencyTeamDepartureController : Controller
    {
        private RescueEntities db = new RescueEntities();

        //
        // GET: /EmergencyTeamDeparture/

        public ActionResult Index()
        {
            var emergencyteamdeparture = db.EmergencyTeamDeparture.Include(e => e.Car).Include(e => e.EmergencyTeam).Include(e => e.Request);
            return View(emergencyteamdeparture.ToList());
        }

        //
        // GET: /EmergencyTeamDeparture/Details/5

        public ActionResult Details(int id = 0)
        {
            EmergencyTeamDeparture emergencyteamdeparture = db.EmergencyTeamDeparture.Find(id);
            if (emergencyteamdeparture == null)
            {
                return HttpNotFound();
            }
            return View(emergencyteamdeparture);
        }

        //
        // GET: /EmergencyTeamDeparture/Create

        public ActionResult Create()
        {
            ViewBag.CarId = new SelectList(db.Car, "CarId", "CarNumber");
            ViewBag.EmergencyTeamId = new SelectList(db.EmergencyTeam, "EmergencyTeamId", "EmergencyTeamName");
            ViewBag.RequestId = new SelectList(db.Request, "RequestId", "DeclarantName");
            return View();
        }

        //
        // POST: /EmergencyTeamDeparture/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmergencyTeamDeparture emergencyteamdeparture)
        {
            if (ModelState.IsValid)
            {
                db.EmergencyTeamDeparture.Add(emergencyteamdeparture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.Car, "CarId", "CarNumber", emergencyteamdeparture.CarId);
            ViewBag.EmergencyTeamId = new SelectList(db.EmergencyTeam, "EmergencyTeamId", "EmergencyTeamName", emergencyteamdeparture.EmergencyTeamId);
            ViewBag.RequestId = new SelectList(db.Request, "RequestId", "DeclarantName", emergencyteamdeparture.RequestId);
            return View(emergencyteamdeparture);
        }

        //
        // GET: /EmergencyTeamDeparture/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EmergencyTeamDeparture emergencyteamdeparture = db.EmergencyTeamDeparture.Find(id);
            if (emergencyteamdeparture == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.Car, "CarId", "CarNumber", emergencyteamdeparture.CarId);
            ViewBag.EmergencyTeamId = new SelectList(db.EmergencyTeam, "EmergencyTeamId", "EmergencyTeamName", emergencyteamdeparture.EmergencyTeamId);
            ViewBag.RequestId = new SelectList(db.Request, "RequestId", "DeclarantName", emergencyteamdeparture.RequestId);
            return View(emergencyteamdeparture);
        }

        //
        // POST: /EmergencyTeamDeparture/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmergencyTeamDeparture emergencyteamdeparture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emergencyteamdeparture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.Car, "CarId", "CarNumber", emergencyteamdeparture.CarId);
            ViewBag.EmergencyTeamId = new SelectList(db.EmergencyTeam, "EmergencyTeamId", "EmergencyTeamName", emergencyteamdeparture.EmergencyTeamId);
            ViewBag.RequestId = new SelectList(db.Request, "RequestId", "DeclarantName", emergencyteamdeparture.RequestId);
            return View(emergencyteamdeparture);
        }

        //
        // GET: /EmergencyTeamDeparture/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EmergencyTeamDeparture emergencyteamdeparture = db.EmergencyTeamDeparture.Find(id);
            if (emergencyteamdeparture == null)
            {
                return HttpNotFound();
            }
            return View(emergencyteamdeparture);
        }

        //
        // POST: /EmergencyTeamDeparture/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmergencyTeamDeparture emergencyteamdeparture = db.EmergencyTeamDeparture.Find(id);
            db.EmergencyTeamDeparture.Remove(emergencyteamdeparture);
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