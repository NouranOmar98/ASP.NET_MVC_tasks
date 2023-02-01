using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Task2.Controllers
{
    public class Task1Controller : Controller
    {
        // GET: Task1
        public ActionResult Show()
        {
            List<Models.Student> students = new List<Models.Student>();

            students.Add(new Models.Student(){ ID=1, Name="Nouran", Major = "PlantProduction", Faculity ="Agricultural", });
            students.Add(new Models.Student() { ID = 2, Name = "Qais", Major = "SoftwareEngineering", Faculity = "IT", });
            students.Add(new Models.Student() { ID = 2, Name = "Wesam", Major = "CivialEngineering", Faculity = "Engineering", });

            return View(students);
        }
    }
}