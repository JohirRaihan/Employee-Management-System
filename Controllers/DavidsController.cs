using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Hr_Management_System.Models;
using iTextSharp.text;
using Rotativa;

namespace Hr_Management_System.Controllers
{
    public class DavidsController : Controller
    {
        private DavidEntities db = new DavidEntities();

        // GET: Davids
        public ActionResult Index()
        {
            return View(db.Davids.ToList());
        }

        public ActionResult PrintPDF()
        {
            DavidEntities context = new DavidEntities();
            List<David> Data = context.Davids.ToList();

            return new PartialViewAsPdf("PrintPDF", Data)
            {

                FileName = "Devids Total Cost.pdf"
            };
        }

        // GET: Davids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            David david = db.Davids.Find(id);
            if (david == null)
            {
                return HttpNotFound();
            }
            return View(david);
        }

        // GET: Davids/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Davids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Cost,Purpose,Details,Total,Date")] David david)
        {
            if (ModelState.IsValid)
            {
                db.Davids.Add(david);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(david);
        }

        // GET: Davids/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            David david = db.Davids.Find(id);
            if (david == null)
            {
                return HttpNotFound();
            }
            return View(david);
        }

        // POST: Davids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Cost,Purpose,Details,Total,Date")] David david)
        {
            if (ModelState.IsValid)
            {
                db.Entry(david).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(david);
        }

        // GET: Davids/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            David david = db.Davids.Find(id);
            if (david == null)
            {
                return HttpNotFound();
            }
            return View(david);
        }

        // POST: Davids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            David david = db.Davids.Find(id);
            db.Davids.Remove(david);
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
