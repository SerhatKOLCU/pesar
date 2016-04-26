using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PESA.Models;

namespace PESA.Controllers
{
    public class DuyurusController : Controller
    {
        private PesaDbEntities db = new PesaDbEntities();

        // GET: Duyurus
        public ActionResult DuyuruIndex()
        {
            return View(db.Duyuru.ToList());
        }

        // GET: Duyurus/Details/5
        public ActionResult DuyuruDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyuru duyuru = db.Duyuru.Find(id);
            if (duyuru == null)
            {
                return HttpNotFound();
            }
            return View(duyuru);
        }

        // GET: Duyurus/Create
        public ActionResult DuyuruCreate()
        {
            return View();
        }

        // POST: Duyurus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DuyuruCreate([Bind(Include = "Duyuru_ID,Duyuru_Baslik,Duyuru_Icerik,Duyuru_Foto,Duyuru_Dosya,Duyuru_Tarih")] Duyuru duyuru)
        {
            if (ModelState.IsValid)
            {
                db.Duyuru.Add(duyuru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(duyuru);
        }

        // GET: Duyurus/Edit/5
        public ActionResult DuyuruEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyuru duyuru = db.Duyuru.Find(id);
            if (duyuru == null)
            {
                return HttpNotFound();
            }
            return View(duyuru);
        }

        // POST: Duyurus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DuyuruEdit([Bind(Include = "Duyuru_ID,Duyuru_Baslik,Duyuru_Icerik,Duyuru_Foto,Duyuru_Dosya,Duyuru_Tarih")] Duyuru duyuru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(duyuru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(duyuru);
        }

        // GET: Duyurus/Delete/5
        public ActionResult DuyuruDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyuru duyuru = db.Duyuru.Find(id);
            if (duyuru == null)
            {
                return HttpNotFound();
            }
            return View(duyuru);
        }

        // POST: Duyurus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DuyuruDeleteConfirmed(int id)
        {
            Duyuru duyuru = db.Duyuru.Find(id);
            db.Duyuru.Remove(duyuru);
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
