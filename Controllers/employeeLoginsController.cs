using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hr_Management_System.Models;

namespace Hr_Management_System.Controllers
{
    public class employeeLoginsController : Controller
    {
        private EmployeeLoginEntities db = new EmployeeLoginEntities();

        // GET: employeeLogins
        public ActionResult Index()
        {
            return View(db.employeeLogins.ToList());
        }

        // GET: employeeLogins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeLogin employeeLogin = db.employeeLogins.Find(id);
            if (employeeLogin == null)
            {
                return HttpNotFound();
            }
            return View(employeeLogin);
        }

        // GET: employeeLogins/Create
        public ActionResult Create()
        {
            employeeLogin elogin = new employeeLogin();
            elogin.Employename = db.Employees.ToList();
            return View(elogin);
        }

        // POST: employeeLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Password")] employeeLogin employeeLogin)
        {
            if (ModelState.IsValid)
            {
                db.employeeLogins.Add(employeeLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeLogin);
        }

        // GET: employeeLogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeLogin employeeLogin = db.employeeLogins.Find(id);
            if (employeeLogin == null)
            {
                return HttpNotFound();
            }
            return View(employeeLogin);
        }

        // POST: employeeLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Password")] employeeLogin employeeLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeLogin);
        }

        // GET: employeeLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeLogin employeeLogin = db.employeeLogins.Find(id);
            if (employeeLogin == null)
            {
                return HttpNotFound();
            }
            return View(employeeLogin);
        }

        // POST: employeeLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employeeLogin employeeLogin = db.employeeLogins.Find(id);
            db.employeeLogins.Remove(employeeLogin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
