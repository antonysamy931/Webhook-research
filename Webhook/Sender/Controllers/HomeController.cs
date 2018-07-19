using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Sender.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {                   
            return RedirectToAction("Test");
        }

        public  ActionResult Test()
        {
            var name = User.Identity.Name;
            ViewBag.Title = "Home Page";
            return View("Index");
        }
    }
}
