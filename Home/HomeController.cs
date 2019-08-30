using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GP_Project.Controllers.Home
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult MeetOurTeam()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
    }
}