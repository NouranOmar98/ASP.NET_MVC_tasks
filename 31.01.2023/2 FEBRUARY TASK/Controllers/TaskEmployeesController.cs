using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2_FEBRUARY_TASK.Models;

namespace _2_FEBRUARY_TASK.Controllers
{
    public class TaskEmployeesController : Controller
    {
        private TaskEntities db = new TaskEntities();

        // GET: TaskEmployees
        public ActionResult Index()
        {
            return View(db.TaskEmployees.ToList());
        }

        // GET: TaskEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEmployee taskEmployee = db.TaskEmployees.Find(id);
            if (taskEmployee == null)
            {
                return HttpNotFound();
            }
            return View(taskEmployee);
        }

        // GET: TaskEmployees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name,Email,Phone,Age,Job_Title,Gender")] TaskEmployee taskEmployee)
        {
            if (ModelState.IsValid)
            {
                db.TaskEmployees.Add(taskEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taskEmployee);
        }

        // GET: TaskEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEmployee taskEmployee = db.TaskEmployees.Find(id);
            if (taskEmployee == null)
            {
                return HttpNotFound();
            }
            return View(taskEmployee);
        }

        // POST: TaskEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name,Email,Phone,Age,Job_Title,Gender")] TaskEmployee taskEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskEmployee);
        }

        // GET: TaskEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEmployee taskEmployee = db.TaskEmployees.Find(id);
            if (taskEmployee == null)
            {
                return HttpNotFound();
            }
            return View(taskEmployee);
        }

        // POST: TaskEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskEmployee taskEmployee = db.TaskEmployees.Find(id);
            db.TaskEmployees.Remove(taskEmployee);
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
