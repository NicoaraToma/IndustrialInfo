using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ezvax.Models;
using System.Data.Entity;

namespace ezvax.Controllers
{
    public class ClinicController : Controller
    {
        //
        // GET: /Clinic/
        public ActionResult Index()
        {
            using (HospitalEntities db = new HospitalEntities())
            {
                return View(db.Clinica.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Clinica clinic)
        {
            try
            {
                using (HospitalEntities db = new HospitalEntities())
                {
                    db.Clinica.Add(clinic);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Edit(int id)
        {
            using (HospitalEntities db = new HospitalEntities())
            {
                return View(db.Clinica.Where(c => c.id == id).FirstOrDefault());
            }

        }

        [HttpPost]

        public ActionResult Edit(int id, Clinica clinic)
        {
            try
            {
                using (HospitalEntities db = new HospitalEntities())
                {
                    db.Entry(clinic).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (HospitalEntities db = new HospitalEntities())
            {
                return View(db.Clinica.Where(c => c.id == id).FirstOrDefault());
            }

        }

        [HttpPost]

        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (HospitalEntities db = new HospitalEntities())
                {
                    Clinica clinic = db.Clinica.Where(c => c.id == id).FirstOrDefault();
                    db.Clinica.Remove(clinic);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}