using ezvax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ezvax.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Profile (int id=0)
        {
            ProfilMedical medicalProfile = new ProfilMedical();
            return View(medicalProfile);
        }
    }
}