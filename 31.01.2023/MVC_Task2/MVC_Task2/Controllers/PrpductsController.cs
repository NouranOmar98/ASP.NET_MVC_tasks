using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Task2.Models;

namespace MVC_Task2.Controllers
{
    public class PrpductsController : Controller
    {
        private Entities db = new Entities();

        // GET: Prpducts
        public ActionResult Index()
        {
            var prpducts = db.Prpducts.Include(p => p.Category);
            return View(prpducts.ToList());
        }

        // GET: Prpducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prpduct prpduct = db.Prpducts.Find(id);
            if (prpduct == null)
            {
                return HttpNotFound();
            }
            return View(prpduct);
        }

        // GET: Prpducts/Create
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Prpducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductName,UnitPrice,UnitsInStock,categoryID")] Prpduct prpduct)
        {
            if (ModelState.IsValid)
            {
                db.Prpducts.Add(prpduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.Categories, "Id", "CategoryName", prpduct.categoryID);
            return View(prpduct);
        }

        // GET: Prpducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prpduct prpduct = db.Prpducts.Find(id);
            if (prpduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.Categories, "Id", "CategoryName", prpduct.categoryID);
            return View(prpduct);
        }

        // POST: Prpducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductName,UnitPrice,UnitsInStock,categoryID")] Prpduct prpduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prpduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.Categories, "Id", "CategoryName", prpduct.categoryID);
            return View(prpduct);
        }

        // GET: Prpducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prpduct prpduct = db.Prpducts.Find(id);
            if (prpduct == null)
            {
                return HttpNotFound();
            }
            return View(prpduct);
        }

        // POST: Prpducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prpduct prpduct = db.Prpducts.Find(id);
            db.Prpducts.Remove(prpduct);
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
