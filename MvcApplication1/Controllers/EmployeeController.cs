using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Web.Security;

namespace MvcApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private RescueEntities db = new RescueEntities();

        //
        // GET: /Employee/

        public ActionResult Index()
        {
            return View(db.Employee.ToList());
        }

        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id = 0)
        {
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
            ViewBag.UserId = new SelectList(db.UserInformation.Where(x => x.Administrator == null && x.Employee == null), "UserId", "UserId");
            ViewBag.JobTitleId = new SelectList(db.JobTitle, "JobTitleId", "JobTitleId");
            return View();
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
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
                        return RedirectToAction("Create", "Operator");
                    }
                    if (employee.JobTitleId == 2)
                    {
                        return RedirectToAction("Create", "Driver");
                    }
                    if (employee.JobTitleId == 2)
                    {
                        return RedirectToAction("Create", "Driver");
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
            Employee employee = db.Employee.Find(id);
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