using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Education()
        {
            return View();
        }
        public ActionResult MyProjects()
        {
            return View();
        }
        public ActionResult Reference()
        {
            return View();
        }
    }
}