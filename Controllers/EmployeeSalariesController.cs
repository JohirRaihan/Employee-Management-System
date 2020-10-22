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
    public class EmployeeSalariesController : Controller
    {
        private EmployeeSalaryEntities db = new EmployeeSalaryEntities();

        // GET: EmployeeSalaries
        public ActionResult Index()
        {
           
            return View(db.EmployeeSalaries.ToList());
        }

        // GET: EmployeeSalaries/pdf/

        public ActionResult PrintPDF()
        {
            EmployeeSalaryEntities context = new EmployeeSalaryEntities();
            List<EmployeeSalary> Data = context.EmployeeSalaries.ToList();

            return new PartialViewAsPdf("PrintPDF", Data)
            {

                FileName = "Employee Salary List.pdf"
            };
        }

        // GET: EmployeeSalaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSalary employeeSalary = db.EmployeeSalaries.Find(id);
            if (employeeSalary == null)
            {
                return HttpNotFound();
            }
            return View(employeeSalary);
        }

        // GET: EmployeeSalaries/Create
        public ActionResult Create()
        {
            EmployeeSalary esalary = new EmployeeSalary();
            esalary.Employename = db.Employees.ToList();
            return View(esalary);
        }

        // POST: EmployeeSalaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Salary,Account_No,Starting_Salary,Increasing_Salary,Date,Status")] EmployeeSalary employeeSalary)
        {

            if (ModelState.IsValid)
            {
              
                db.EmployeeSalaries.Add(employeeSalary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeSalary);
        }


        // GET: EmployeeSalaries/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSalary employeeSalary = db.EmployeeSalaries.Find(id);
            if (employeeSalary == null)
            {
                return HttpNotFound();
            }
            //EmployeeSalary esalary = new EmployeeSalary();
            //esalary.Employename = db.Employees.ToList();
            return View(employeeSalary);
        }

        // POST: EmployeeSalaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Salary,Account_No,Starting_Salary,Increasing_Salary,Date,Status")] EmployeeSalary employeeSalary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeSalary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeSalary);
        }

        // GET: EmployeeSalaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSalary employeeSalary = db.EmployeeSalaries.Find(id);
            if (employeeSalary == null)
            {
                return HttpNotFound();
            }
            return View(employeeSalary);
        }

        // POST: EmployeeSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeSalary employeeSalary = db.EmployeeSalaries.Find(id);
            db.EmployeeSalaries.Remove(employeeSalary);
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
