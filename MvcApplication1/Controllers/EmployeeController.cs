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
    public class EmployeeController : Controller
    {
        private RescueEntities db = new RescueEntities();

        //
        // GET: /Employee/

        public ActionResult Index()
        {
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            return View(db.Employee.ToList());
        }

        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!(Roles.IsUserInRole("Administrator") || Roles.IsUserInRole("Employee")))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // GET: /Employee/Create

        public ActionResult Create()
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            ViewBag.UserId = new SelectList(db.UserInformation.Where(x => x.Administrator == null && x.Employee == null), "UserId", "UserId");
            ViewBag.JobTitleId = new SelectList(db.JobTitle, "JobTitleId", "JobTitleName");
            return View();
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            if (ModelState.IsValid)
            {
                if (db.Employee.Where(x => x.UserId == employee.UserId).Count() == 0)
                {
                    employee.JobTitle = db.JobTitle.Find(employee.JobTitleId);
                    db.SaveChanges();
                    db.Employee.Add(employee);
                    db.SaveChanges();
                    employee.UserInformation = db.UserInformation.First(x => x.UserId == employee.UserId);
                    db.SaveChanges();
                    employee.UserInformation.UserProfile = db.UserProfile.First(x => x.UserId == employee.UserInformation.UserId);
                    db.SaveChanges();
                    Roles.AddUserToRole(employee.UserInformation.UserProfile.UserName, "Employee");
                    
                    if (employee.JobTitleId == 1)
                    {
                        return RedirectToAction("Edit", "Operator", new { id = employee.UserId });
                    }
                    if (employee.JobTitleId == 2)
                    {
                        return RedirectToAction("Edit", "Driver", new { id = employee.UserId });
                    }
                    if (employee.JobTitleId == 3)
                    {
                        return RedirectToAction("Edit", "Rescuer", new { id = employee.UserId });
                    }

                }
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        //
        // GET: /Employee/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!(Roles.IsUserInRole("Administrator") || WebSecurity.CurrentUserId == id))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            Employee employee = db.Employee.Find(id);
            ViewBag.JobTitleId = new SelectList(db.JobTitle, "JobTitleId", "JobTitleName",employee.JobTitleId);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (!(Roles.IsUserInRole("Administrator") || WebSecurity.CurrentUserId == employee.UserId))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //
        // GET: /Employee/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("HttpError404", "Error");
            }
            Employee employee = db.Employee.Find(id);
            Roles.RemoveUserFromRole(employee.UserInformation.UserProfile.UserName, "Employee");
            db.SaveChanges();
            db.Employee.Remove(employee);
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