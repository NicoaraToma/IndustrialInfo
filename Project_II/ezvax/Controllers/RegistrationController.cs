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
        public ActionResult SingUp()
        {
            Users userModel = new Users();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult SingUp(Users userModel)
        {
            using (HospitalEntities dbModel = new HospitalEntities())
            {
                var userDetails = dbModel.Users.Where(u => u.CNP == userModel.CNP).FirstOrDefault();
               
                if (userDetails!=null)
                {
                    ViewBag.DuplicateMessage = "CNP already registered.";
                    return View("SingUp", userModel);
                }
                if (userModel.ValidareCNP() == false)
                {
                    ViewBag.ErrorMessage = "CNP is invalid";
                    return View("SingUp", userModel);
                }
                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("SingUp", new Users());
        }
    }
}