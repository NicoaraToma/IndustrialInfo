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
            Admin adminModel = new Admin();
            return View(adminModel);
        }
        [HttpPost]
        public ActionResult AdminAuth(Admin adminModel)
        {
            using (HospitalEntities db = new HospitalEntities())
            {
                var adminDetails = db.Admin.Where(a => a.userAdmin ==adminModel.userAdmin && a.password == adminModel.password).FirstOrDefault();
                if (adminDetails == null)
                {
                    adminModel.AdminErrorMessage = "User sau parola gresita!";
                    return View("AdminAuth", adminModel);
                }
                else
                {
                    Session["adminID"] = adminModel.id;
                    Session["userAdmin"] = adminModel.userAdmin;
                    return RedirectToAction("Index", "Stock");
                }
            }
        }
        public ActionResult LogOut()
        {
            int adminId = (int)Session["adminID"];
            Session.Abandon();
            return RedirectToAction("AdminAuth", "Admin");
        }
    }
}