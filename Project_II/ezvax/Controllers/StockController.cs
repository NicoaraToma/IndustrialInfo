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
        // GET: Stock
        public ActionResult Index()
        {
            var stock = db.Stoc.Include(s => s.Clinica);
            return View(stock.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stoc stock = db.Stoc.Find(id);
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
                var stocDetails = db.Stoc.Where(s => s.id == stock.id).FirstOrDefault();
                if (stocDetails != null)
                {
                    ViewBag.DuplicateMessage = "Stock already registered.";
                    return View("Create", stock);

                }
                db.Stoc.Add(stock);
                db.SaveChanges();
                
            };
            ModelState.Clear();
            ViewBag.SuccessMessage = "Stoc add successfully.";
            stock = new Stoc();
            using (HospitalEntities db = new HospitalEntities())
            {
                var stocDetails = db.Stoc.Where(s => s.id == stock.id).FirstOrDefault();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stoc stock = db.Stoc.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            using (HospitalEntities db = new HospitalEntities()) {
            stock.clinicaList = db.Clinica.ToList<Clinica>();
            }
            return View(stock);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
            Stoc stoc = db.Stoc.Find(id);
            if (stoc == null)
            {
                return HttpNotFound();
            }
            return View(stoc);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stoc stock = db.Stoc.Find(id);
            db.Stoc.Remove(stock);
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