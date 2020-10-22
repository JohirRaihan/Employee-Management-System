using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hr_Management_System.Models;
using Rotativa;

namespace Hr_Management_System.Controllers
{
    public class E_WorkController : Controller
    {
        private E_WorkEntities db = new E_WorkEntities();

        // GET: E_Work
        public ActionResult Index()
        {
            return View(db.E_Work.ToList());
        }

        // GET: EmployeeWorks/pdf/

        public ActionResult PrintPDF()
        {
            E_WorkEntities context = new E_WorkEntities();
            List<E_Work> Data = context.E_Work.ToList();

            return new PartialViewAsPdf("PrintPDF", Data)
            {

                FileName = "Employee Works List.pdf"
            };
        }

        // GET: E_Work/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Work e_Work = db.E_Work.Find(id);
            if (e_Work == null)
            {
                return HttpNotFound();
            }
            return View(e_Work);
        }

        // GET: E_Work/Create
        public ActionResult Create()
        {
            E_Work employeeW = new E_Work();
            employeeW.Employename = db.Employees.ToList();
            return View(employeeW);
        }

        // POST: E_Work/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_Name,Duration,Price,Status,Start_Date,End_Date")] E_Work e_Work)
        {
            if (ModelState.IsValid)
            {
                db.E_Work.Add(e_Work);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(e_Work);
        }

        // GET: E_Work/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Work e_Work = db.E_Work.Find(id);
            if (e_Work == null)
            {
                return HttpNotFound();
            }
            return View(e_Work);
        }

        // POST: E_Work/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_Name,Duration,Price,Status,Start_Date,End_Date")] E_Work e_Work)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e_Work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e_Work);
        }

        // GET: E_Work/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Work e_Work = db.E_Work.Find(id);
            if (e_Work == null)
            {
                return HttpNotFound();
            }
            return View(e_Work);
        }

        // POST: E_Work/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            E_Work e_Work = db.E_Work.Find(id);
            db.E_Work.Remove(e_Work);
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
