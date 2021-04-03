using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covid19Proiect.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            DataBaseManager dbm = new DataBaseManager();
            dbm.getUsers();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}