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
    public class RequestController : Controller
    {
        private RescueEntities db = new RescueEntities();

        //
        // GET: /Request/

        public ActionResult Index(int? Status)
        {
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee") || Roles.IsUserInRole("User")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            //var request = db.Request.Include(r => r.Operator).Include(r => r.RequestStatus).Include(r => r.RequestType);
            IEnumerable<Request> list = db.Request.Include(r => r.Operator).Include(r => r.RequestStatus).Include(r => r.RequestType);

            if (Status == null) list = db.Request.Include(r => r.Operator).Include(r => r.RequestStatus).Include(r => r.RequestType);
            else if((Status == 1) || (Status == 2) || (Status == 3)) list = list.Where(z => z.RequestStatusId == Status);

            return View(list.ToList());
        }


        //
        // GET: /Request/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee") || Roles.IsUserInRole("User")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            Request request = db.Request.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            var RequestOperator = db.Database.SqlQuery<GetRequestOperatorFIO_Result>("SELECT * FROM [dbo].[GetRequestOperatorFIO](N'" + request.RequestId.ToString() + "')");
            string OperatorFIO = RequestOperator.FirstOrDefault().LastName + " " + RequestOperator.FirstOrDefault().FirstName + " " + RequestOperator.FirstOrDefault().SecondName;

            var HeadRescue = db.Database.SqlQuery<GetRequestHeadRescuerFIO_Result>("SELECT * FROM [dbo].[GetRequestHeadRescuerFIO](N'" + request.RequestId.ToString() + "')");
            string HeadRescueFIO = "";
            if (HeadRescue.Count() > 0)
            {
                HeadRescueFIO = HeadRescue.FirstOrDefault().LastName + " " + HeadRescue.FirstOrDefault().FirstName + " " + HeadRescue.FirstOrDefault().SecondName;
            }

            if (String.IsNullOrWhiteSpace(HeadRescueFIO)) HeadRescueFIO = "Данная заявка ещё не была обработана или является ложной";
            ViewBag.OperatorFIO = OperatorFIO;
            ViewBag.HeadRescueFIO = HeadRescueFIO;
            return View(request);
        }

        //
        // GET: /Request/Create

        public ActionResult Create()
        {
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee") || Roles.IsUserInRole("User")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            if (!(User.IsInRole("Administrator") || User.IsInRole("Employee")))
            {
                ViewBag.UserId = new SelectList(db.Operator.Take(2), "UserId", "WorkShift", db.Operator.FirstOrDefault().UserId);
                ViewBag.RequestStatusId = new SelectList(db.RequestStatus.Where(z => z.RequestStatusId == 1), "RequestStatusId", "RequestStatusName", 1);
                ViewBag.RequestTypeId = new SelectList(db.RequestType.Where(z => z.RequestTypeId == 2), "RequestTypeId", "RequestTypeName", 2);
            }
            else 
            if((User.IsInRole("Employee") && db.Operator.Find(WebSecurity.CurrentUserId)!= null)||(User.IsInRole("Administrator")))
            {
                ViewBag.UserId = new SelectList(db.Operator, "UserId", "UserId", db.Operator.First().UserId);
                ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "RequestStatusId", "RequestStatusName", 1);
                ViewBag.RequestTypeId = new SelectList(db.RequestType, "RequestTypeId", "RequestTypeName", 1);
            }
            return View();
        }

        //
        // POST: /Request/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Request request)
        {
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee") || Roles.IsUserInRole("User")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            if (ModelState.IsValid)
            {
                db.Request.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (!(User.IsInRole("Administrator") || User.IsInRole("Employee")))
            {
                ViewBag.UserId = new SelectList(db.Operator.Take(2), "UserId", "WorkShift", db.Operator.FirstOrDefault().UserId);
                ViewBag.RequestStatusId = new SelectList(db.RequestStatus.Where(z => z.RequestStatusId == 1), "RequestStatusId", "RequestStatusName", 1);
                ViewBag.RequestTypeId = new SelectList(db.RequestType.Where(z => z.RequestTypeId == 2), "RequestTypeId", "RequestTypeName", 2);
            }
            else
                if ((User.IsInRole("Employee") && db.Operator.Find(WebSecurity.CurrentUserId) != null) || (User.IsInRole("Administrator")))
                {
                    ViewBag.UserId = new SelectList(db.Operator, "UserId", "UserId", db.Operator.First().UserId);
                    ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "RequestStatusId", "RequestStatusName", 1);
                    ViewBag.RequestTypeId = new SelectList(db.RequestType, "RequestTypeId", "RequestTypeName", 1);
                }
            return View(request);
        }

        //
        // GET: /Request/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            Request request = db.Request.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Operator, "UserId", "UserId", request.UserId);
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
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Operator, "UserId", "UserId", request.UserId);
            ViewBag.RequestStatusId = new SelectList(db.RequestStatus, "RequestStatusId", "RequestStatusName", request.RequestStatusId);
            ViewBag.RequestTypeId = new SelectList(db.RequestType, "RequestTypeId", "RequestTypeName", request.RequestTypeId);
            return View(request);
        }

        //
        // GET: /Request/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
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
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
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