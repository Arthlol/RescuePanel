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
    public class OperatorController : Controller
    {
        private RescueEntities db = new RescueEntities();

        //
        // GET: /Operator/

        public ActionResult Index()
        {
            var @operator = db.Operator.Include(o => o.Employee);
            return View(@operator.ToList());
        }

        //
        // GET: /Operator/Details/5

        public ActionResult Details(int id = 0)
        {
            Operator @operator = db.Operator.Find(id);
            if (@operator == null)
            {
                return HttpNotFound();
            }
            return View(@operator);
        }

        //
        // GET: /Operator/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Employee, "UserId", "UserId");
            return View();
        }

        //
        // POST: /Operator/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Operator @operator)
        {
            if (ModelState.IsValid)
            {
                db.Operator.Add(@operator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Employee, "UserId", "WorkPhone", @operator.UserId);
            return View(@operator);
        }

        //
        // GET: /Operator/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Operator @operator = db.Operator.Find(id);
            if (@operator == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Employee, "UserId", "WorkPhone", @operator.UserId);
            return View(@operator);
        }

        //
        // POST: /Operator/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Operator @operator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@operator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Employee, "UserId", "WorkPhone", @operator.UserId);
            return View(@operator);
        }

        //
        // GET: /Operator/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Operator @operator = db.Operator.Find(id);
            if (@operator == null)
            {
                return HttpNotFound();
            }
            return View(@operator);
        }

        //
        // POST: /Operator/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operator @operator = db.Operator.Find(id);
            db.Operator.Remove(@operator);
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