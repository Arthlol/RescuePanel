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
    public class RescueEquipmentSetController : Controller
    {
        private RescueEntities db = new RescueEntities();

        //
        // GET: /RescueEquipmentSet/

        public ActionResult Index()
        {
            var rescueequipmentset = db.RescueEquipmentSet.Include(r => r.Car);
            return View(rescueequipmentset.ToList());
        }

        //
        // GET: /RescueEquipmentSet/Details/5

        public ActionResult Details(int id = 0)
        {
            RescueEquipmentSet rescueequipmentset = db.RescueEquipmentSet.Find(id);
            if (rescueequipmentset == null)
            {
                return HttpNotFound();
            }
            return View(rescueequipmentset);
        }

        //
        // GET: /RescueEquipmentSet/Create

        public ActionResult Create()
        {
            ViewBag.CarId = new SelectList(db.Car, "CarId", "CarNumber");
            return View();
        }

        //
        // POST: /RescueEquipmentSet/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RescueEquipmentSet rescueequipmentset)
        {
            if (ModelState.IsValid)
            {
                db.RescueEquipmentSet.Add(rescueequipmentset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.Car, "CarId", "CarNumber", rescueequipmentset.CarId);
            return View(rescueequipmentset);
        }

        //
        // GET: /RescueEquipmentSet/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RescueEquipmentSet rescueequipmentset = db.RescueEquipmentSet.Find(id);
            if (rescueequipmentset == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.Car, "CarId", "CarNumber", rescueequipmentset.CarId);
            return View(rescueequipmentset);
        }

        //
        // POST: /RescueEquipmentSet/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RescueEquipmentSet rescueequipmentset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rescueequipmentset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.Car, "CarId", "CarNumber", rescueequipmentset.CarId);
            return View(rescueequipmentset);
        }

        //
        // GET: /RescueEquipmentSet/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RescueEquipmentSet rescueequipmentset = db.RescueEquipmentSet.Find(id);
            if (rescueequipmentset == null)
            {
                return HttpNotFound();
            }
            return View(rescueequipmentset);
        }

        //
        // POST: /RescueEquipmentSet/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RescueEquipmentSet rescueequipmentset = db.RescueEquipmentSet.Find(id);
            db.RescueEquipmentSet.Remove(rescueequipmentset);
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