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
        [HttpGet]
        public ActionResult MedicalProfile(int id=0)
        {
            ProfilMedical medicalProfile = new ProfilMedical();
           using (HospitalEntities dbModel=new HospitalEntities())
            {
                medicalProfile.simptomes = dbModel.Simptome.ToList<Simptome>();
                medicalProfile.genders = dbModel.Gen.ToList<Gen>();
                medicalProfile.grupeSange = dbModel.GrupeSange.ToList<GrupeSange>();
                medicalProfile.Anticorpis = dbModel.Anticorpi.ToList<Anticorpi>();
            };
            return View(medicalProfile); 
        }
        [HttpPost]
        public ActionResult MedicalProfile(ProfilMedical medicalProfile)
        {
         
            using (HospitalEntities dbModel = new HospitalEntities())
            {
                medicalProfile.simptomes = dbModel.Simptome.ToList<Simptome>();
                medicalProfile.genders = dbModel.Gen.ToList<Gen>();
                medicalProfile.grupeSange = dbModel.GrupeSange.ToList<GrupeSange>();
                medicalProfile.Anticorpis = dbModel.Anticorpi.ToList<Anticorpi>();
                medicalProfile.idUser = (int)Session["userID"];
                if (dbModel.ProfilMedical.Any(x => x.idUser == medicalProfile.idUser))
                {
                    ViewBag.DuplicateMessage = "ID already registered.";
                    return View("MedicalProfile", medicalProfile);
                }
                medicalProfile.ageErrorMessage = "Varsta minima este de 18 ani.";
                dbModel.ProfilMedical.Add(medicalProfile);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Profile registration Successful.";
            medicalProfile = new ProfilMedical();
            using (HospitalEntities dbModel = new HospitalEntities())
            {
                medicalProfile.genders = dbModel.Gen.ToList<Gen>();
                medicalProfile.grupeSange = dbModel.GrupeSange.ToList<GrupeSange>();
                medicalProfile.simptomes = dbModel.Simptome.ToList<Simptome>();
                medicalProfile.Anticorpis = dbModel.Anticorpi.ToList<Anticorpi>();
            };
            return View("MedicalProfile",medicalProfile);
        }
    }
}