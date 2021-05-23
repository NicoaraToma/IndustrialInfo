using ezvax.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ezvax.Controllers
{
    public class VaccineController : Controller
    {
        private HospitalEntities db = new HospitalEntities();
        // GET: Stock
        public ActionResult Index()
        {
            return View(db.Vaccin.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccin vaccinModel = db.Vaccin.Find(id);
            if (vaccinModel == null)
            {
                return HttpNotFound();
            }
            return View(vaccinModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Vaccin vaccinModel = new Vaccin();
            return View(vaccinModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vaccin vaccinModel)
        { 
        var vaccinDetails = db.Vaccin.Where(v => v.id == vaccinModel.id).FirstOrDefault();
        if (vaccinDetails != null)
          {
             ViewBag.DuplicateMessage = "Vaccin deja inregistrat!";
             return View("Create", vaccinModel);

          }
          db.Vaccin.Add(vaccinModel);
          db.SaveChanges();

          ModelState.Clear();
            ViewBag.SuccessMessage = "Vaccin adaugat cu succes!";
          return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccin vaccinModel = db.Vaccin.Find(id);
            if (vaccinModel == null)
            {
                return HttpNotFound();
            }
            return View(vaccinModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nume,durataRapel,cantitate,contraindicatii,alergii")]Vaccin vaccinModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccinModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vaccinModel);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccin vaccinModel = db.Vaccin.Find(id);
            if (vaccinModel == null)
            {
                return HttpNotFound();
            }
            return View(vaccinModel);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaccin vaccinModel = db.Vaccin.Find(id);
            db.Vaccin.Remove(vaccinModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}