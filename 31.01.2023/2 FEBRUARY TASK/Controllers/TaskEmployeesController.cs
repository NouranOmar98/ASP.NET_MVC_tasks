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

        [HttpGet]
        public ActionResult Index(string searchString, string searchBy)
        {
            //var taskEmployees = from t in db.TaskEmployees select t;
            var taskEmployees = from t in db.TaskEmployees select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                switch (searchBy)
                {
                    case "First Name":
                        taskEmployees = taskEmployees.Where(s => s.First_Name.Contains(searchString));
                        break;
                    case "Last Name":
                        taskEmployees = taskEmployees.Where(s => s.Last_Name.Contains(searchString));
                        break;
                    case "Email":
                        taskEmployees = taskEmployees.Where(s => s.Email.Contains(searchString));
                        break;
                    default:
                        taskEmployees = taskEmployees.Where(s => s.First_Name.Contains(searchString) || s.Last_Name.Contains(searchString) || s.Job_Title.Contains(searchString) || s.Age.ToString().Equals(searchString));
                        break;
                }
            }
            if (taskEmployees.ToList().Count <= 0 || searchString == "")
            {
                ViewBag.SearchString = "Not Found";
            }
            return View(taskEmployees.ToList());
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
        public ActionResult Create(TaskEmployee taskEmployee , HttpPostedFileBase img , HttpPostedFileBase File)

        {
            if ( img!= null)
            {
                string path = Server.MapPath("../Images/") + img.FileName;
                img.SaveAs(path);
                taskEmployee.img = img.FileName;
            }

            if (File != null)
            {
                string path = Server.MapPath("../CV/") + File.FileName;
                File.SaveAs(path);
                taskEmployee.PdfFile = File.FileName;
            }

            db.TaskEmployees.Add(taskEmployee);
            db.SaveChanges();
            return View(taskEmployee);

           
        }


        public FileResult Download(string CV)
        {
            string name="../CV/"+CV ; 
            string path = Server.MapPath(name);
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "application.pdf", CV);
            
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
