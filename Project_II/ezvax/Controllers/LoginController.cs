using ezvax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ezvax.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Authentification()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(ezvax.Models.Users userModel)
        {
            using (HospitalEntities db = new HospitalEntities())
            {
                var userDetails = db.Users.Where(x => x.CNP == userModel.CNP && x.password == userModel.password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong CNP or password.";
                    return View("Authentification", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.id;
                    Session["userName"] = userDetails.nume;
                    return RedirectToAction("MedicalProfile", "Profile");
                }
            }
        }
        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Authentification", "Login");
        }
    }
}
    