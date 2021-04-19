using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EZVax_Final.Models;
using System.Web.Mvc;

namespace EZVax_Final.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult AddOrEdit()
        {
            Users userModel = new Users();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(Users userModel)
        {
            using (HospitalEntities dbModel = new HospitalEntities())
            {
                if (dbModel.Users.Any(x => x.CNP == userModel.CNP))
                {
                    ViewBag.DuplicateMessage = "CNP already registered.";
                    return View("AddOrEdit", userModel);
                }

                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("AddOrEdit", new Users());
        }
    }
}