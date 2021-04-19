using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ezvax.Models;
using System.Web.Mvc;

namespace ezvax.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            Users userModel = new Users();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult Register(Users userModel)
        {
            using (HospitalEntities dbModel = new HospitalEntities())
            {
                if (dbModel.Users.Any(x => x.CNP == userModel.CNP))
                {
                    ViewBag.DuplicateMessage = "CNP already registered.";
                    return View("Register", userModel);
                }

                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("Register", new Users());
        }
    }
}