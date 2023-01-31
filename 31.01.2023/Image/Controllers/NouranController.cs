using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Image.Controllers
{
    public class NouranController : Controller
    {
        // GET: Nouran

        //RedirectToGoogle
        public ActionResult RedirectToGoogle()
        {
            return Redirect("https://www.google.com");
        }

        //TextData
        public ContentResult TextData()
        {
            string text = "Hello My Name Is Nouran";
            return Content(text, "text/plain");
        }

        //NotFound (Error hhh) :)) 

        public ActionResult NotFound()
        {
            return View("NotFound", null, HttpStatusCode.NotFound);
        }

        //

        //public FileResult Download()
        //{
        //    byte[] fileBytes = System.IO.File.ReadAllBytes("path/to/file.pdf");
        //    return File(fileBytes, "application/pdf", "file.pdf");
        //}

        //

        public JsonResult Contact()
        {
            return Json(new { message = "Please Tap Twice to Download The Image :))" });
        }

    }
}