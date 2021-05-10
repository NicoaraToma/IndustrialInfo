using ezvax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ezvax.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminAuth()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(Admin adminModel)
        {
            using (HospitalEntities db = new HospitalEntities())
            {
                var userDetails = db.Users.Where(x => x.CNP ==adminModel.userAdmin && x.password == adminModel.password).FirstOrDefault();
                if (userDetails == null)
                {
                    adminModel.AdminErrorMessage = "Wrong username or password.";
                    return View("Login", adminModel);
                }
                else
                {
                    Session["userID"] = adminModel.id;
                    Session["userName"] = adminModel.userAdmin;
                    return RedirectToAction("MedicalProfile", "Profile");
                }
            }
        }
        public ActionResult LogOut()
        {
            int adminId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("AdminAuth", "Admin");
        }
    }
}