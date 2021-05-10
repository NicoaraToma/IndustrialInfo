using ezvax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ezvax.Controllers
{
    public class SchedulerController : Controller
    {
        // GET: Scheduler
        [HttpGet]
        public ActionResult Appointment()
        {
            Programare programare = new Programare();
            ProfilMedical profilMedical = new ProfilMedical();
            using (HospitalEntities dbModel = new HospitalEntities())
            {
                programare.clinici = dbModel.Clinica.ToList<Clinica>();
                programare.vaccine = dbModel.Vaccin.ToList<Vaccin>();
                if (dbModel.ProfilMedical.Any(x => x.idUser == profilMedical.idUser))
                {
                    Session["profileID"] = profilMedical.id;
                }
            }
            return View(programare);
        }
        [HttpPost]
        public ActionResult Appointment(Programare programareModel)
        {
            using (HospitalEntities dbModel = new HospitalEntities())
            {
                programareModel.idUser = (int)Session["userID"];
                programareModel.clinici = dbModel.Clinica.ToList<Clinica>();
                programareModel.vaccine = dbModel.Vaccin.ToList<Vaccin>();
                if (dbModel.Programare.Any(x => x.idUser == programareModel.idUser))
                {
                    ViewBag.DuplicateMessage = "Appointment already registered.";
                    return View("Appointment", programareModel);
                }
                
                dbModel.Programare.Add(programareModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            using (HospitalEntities dbModel = new HospitalEntities())
            {
                programareModel.clinici = dbModel.Clinica.ToList<Clinica>();
                programareModel.vaccine = dbModel.Vaccin.ToList<Vaccin>();
            }
            ViewBag.SuccessMessage = "Appointment Successful.";
            return View("Appointment", new Programare());
        }
    }
}