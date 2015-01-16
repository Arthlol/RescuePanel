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
    public class RequestController : Controller
    {
        private RescueEntities db = new RescueEntities();

        //
        // GET: /Request/

        public ActionResult Index()
        {
            var request = db.Request.Include(r => r.Operator).Include(r => r.RequestStatus).Include(r => r.RequestType);
            return View(request.ToList());
        }

        //
        // GET: /Request/Details/5

        public ActionResult Details(int id = 0)
        {
            Request request = db.Request.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        //
        // GET: /Request/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Operator, "UserId", "userId");
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "RequestStatusId", "RequestStatusName");
            ViewBag.RequestTypeId = new SelectList(db.RequestType, "RequestTypeId", "RequestTypeName");
            return View();
        }

        //
        // POST: /Request/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Request.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Operator, "UserId", "WorkShift", request.UserId);
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "RequestStatusId", "RequestStatusName", request.RequestStatusId);
            ViewBag.RequestTypeId = new SelectList(db.RequestType, "RequestTypeId", "RequestTypeName", request.RequestTypeId);
            return View(request);
        }

        //
        // GET: /Request/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Request request = db.Request.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Operator, "UserId", "WorkShift", request.UserId);
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "RequestStatusId", "RequestStatusName", request.RequestStatusId);
            ViewBag.RequestTypeId = new SelectList(db.RequestType, "RequestTypeId", "RequestTypeName", request.RequestTypeId);
            return View(request);
        }

        //
        // POST: /Request/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Operator, "UserId", "WorkShift", request.UserId);
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "RequestStatusId", "RequestStatusName", request.RequestStatusId);
            ViewBag.RequestTypeId = new SelectList(db.RequestType, "RequestTypeId", "RequestTypeName", request.RequestTypeId);
            return View(request);
        }

        //
        // GET: /Request/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Request request = db.Request.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        //
        // POST: /Request/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Request.Find(id);
            db.Request.Remove(request);
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