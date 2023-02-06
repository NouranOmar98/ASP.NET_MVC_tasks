using _6_FEBRUARY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _6_FEBRUARY.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private TaskEntities db = new TaskEntities();

        public ActionResult Customers()
        {
            return View(db.Customers.ToList());

        }

        public PartialViewResult Orders()
        
        { 
             
            return PartialView(db.Orders.ToList().Last());
        
        }

    }
}