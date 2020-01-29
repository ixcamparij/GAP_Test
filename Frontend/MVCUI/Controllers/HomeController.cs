using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string APIDomain = ConfigurationManager.AppSettings["APIDomain"];
            ViewBag.APIDomain = APIDomain;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AssignPolicy()
        {
            string APIDomain = ConfigurationManager.AppSettings["APIDomain"];
            ViewBag.APIDomain = APIDomain;
            ViewBag.Message = "This section is for assign a policies to customers";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}