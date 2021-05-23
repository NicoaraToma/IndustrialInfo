using ezvax.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace ezvax.Controllers
{
    public class StockController : Controller
    {
        private HospitalEntities db=new HospitalEntities();
        public ActionResult Index()
        {
            var stock = db.vaccin.Include(s => s.Clinica);
            return View(stock.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stoc stock = db.vaccin.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Stoc stock = new Stoc();
            using (HospitalEntities db=new HospitalEntities()) {
                stock.clinicaList = db.Clinica.ToList<Clinica>();
                return View(stock);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Stoc stock)
        {
            using (HospitalEntities db = new HospitalEntities())
            {
                stock.clinicaList = db.Clinica.ToList<Clinica>();
                var stocDetails = db.vaccin.Where(s => s.id == stock.id).FirstOrDefault();
                if (stocDetails != null)
                {
                    ViewBag.DuplicateMessage = "Stoc deja inregistrat!";
                    return View("Create", stock);

                }
                db.vaccin.Add(stock);
                db.SaveChanges();
                
            };
            ModelState.Clear();
            ViewBag.SuccessMessage = "Stoc inregistrat cu succes!";
            using (HospitalEntities db = new HospitalEntities())
            {
                stock.clinicaList = db.Clinica.ToList<Clinica>();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stoc stock = db.vaccin.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            using (HospitalEntities db = new HospitalEntities()) {
            stock.clinicaList = db.Clinica.ToList<Clinica>();
            }
            return View(stock);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idClinica,stocAstraZeneca,stocPfizer,stocSputnik,StocModerna")] Stoc stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            stock = new Stoc();
            using (HospitalEntities db = new HospitalEntities())
            {
                stock.clinicaList = db.Clinica.ToList<Clinica>();
            }
            return View(stock);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stoc stoc = db.vaccin.Find(id);
            if (stoc == null)
            {
                return HttpNotFound();
            }
            return View(stoc);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stoc stock = db.vaccin.Find(id);
            db.vaccin.Remove(stock);
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