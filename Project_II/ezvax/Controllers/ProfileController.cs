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
                var profilMedical = dbModel.ProfilMedical.Where(p => p.idUser == medicalProfile.idUser).FirstOrDefault();
                medicalProfile.idUser =(int) Session["userID"];
                if (profilMedical!=null)
                {
                    ViewBag.DuplicateMessage = "Profil medical deja inregistrat!";
                    return View("MedicalProfile", medicalProfile);
                }

                dbModel.ProfilMedical.Add(medicalProfile);
                dbModel.SaveChanges();
            };
            ModelState.Clear();
            ViewBag.SuccessMessage = "Profil medical inregistrat cu succes!";
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