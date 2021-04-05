using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EZVax.Models;
namespace EZVax.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            Users userModel = new Users();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(Users userModel)
        {
            using (HospitalEntities db = new HospitalEntities())
            {
                if(db.Users.Any(x => x.CNP == userModel.CNP))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("AddOrEdit", userModel);
                }
                db.Users.Add(userModel);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration successful";
            return View("AddOrEdit",new Users());
        }
    }
}