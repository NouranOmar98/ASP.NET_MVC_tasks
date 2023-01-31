using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Image.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        //public string About()
        //{
        //    return "This Image Show A beutiful Animal";
        //}
        public string Contact()
        {
            return "PLease Tap Twice to Download The Image :))";
        }
        public string image()
        {
           
            return ("<a download='Task.jpg' href='../Images/Task.jpg'><img src='../images/Task.jpg'/></a>");
        }
        //public FileContentResult DownloadContent()
        //{

        //    var path = Server.MapPath("../Images/Task.jpg");

        //    Response.AddHeader("Content-Disposition", "attachment;filename=DealerAdTemplate.jpg");
        //    Response.WriteFile(path);
        //    Response.End();
        //    return null;
        //}

    }
}