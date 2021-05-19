using ezvax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ezvax.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        [HttpGet]
        public ActionResult Registration(int id=0)
        {
            Users userModel = new Users();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult SignUp(Users userModel)
        {
            using (HospitalEntities dbModel = new HospitalEntities())
            {
                var userDetails = dbModel.Users.Where(u => u.CNP == userModel.CNP).FirstOrDefault();
                if (userDetails != null)
                {
                    ViewBag.DuplicateMessage = "User already registered";
                    return View("Registration", userModel);
                }
                if (userModel.ValidareCNP() == false)
                {
                    userModel.cnpErrorMessage = "CNP format is invalid";
                    return View("Registration", userModel);
                }
                if (userModel.ValidareTel() == false)
                {
                    userModel.telErrorMessage = "Phone number is incorect";
                    return View("Registration", userModel);
                }
                if (userModel.ValidarePass() == false)
                {
                    userModel.passErrorMessage = "Pass format is invalid";
                    return View("Registration", userModel);
                }
                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
                ModelState.Clear();
                ViewBag.SuccessMessage = "User registration Successful.";
                return RedirectToAction("Authentification", "Login");
                
            }
        }
    }
}