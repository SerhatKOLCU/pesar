using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PESA.Models;
using System.IO;

namespace PESA.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        private PesaDbEntities db = new PesaDbEntities();

        #region YAYIN

        // GET: Yayin
        public ActionResult YayinIndex()
        {
            var yayin = db.Yayin.Include(y => y.YayinTip).Include(y => y.Yazar);
            return View(yayin.ToList());
        }

        // GET: Yayin/Details/5
        public ActionResult YayinDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yayin yayin = db.Yayin.Find(id);
            if (yayin == null)
            {
                return HttpNotFound();
            }
            return View(yayin);
        }

        // GET: Yayin/Create
        public ActionResult YayinCreate()
        {
            ViewBag.YayinTip_ID = new SelectList(db.YayinTip, "YayinTip_ID", "YayinTip_Adi");
            ViewBag.Yazar_ID = new SelectList(db.Yazar, "Yazar_ID", "Yazar_Adi");
            return View();
        }

        // POST: Yayin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YayinCreate([Bind(Include = "Yayin_ID,YayinTip_ID,Yayin_Baslik,Yayin_Foto,Yayin_Icerik,Yayin_Ozet,Yazar_ID,Etiket_ID,Yayin_Dosya,Yayin_Tarih,Slider_Baslik,Slider_Ozet")] Yayin yayin)
        {
            if (ModelState.IsValid)
            {
                db.Yayin.Add(yayin);
                db.SaveChanges();
                return RedirectToAction("YayinIndex");
            }

            ViewBag.YayinTip_ID = new SelectList(db.YayinTip, "YayinTip_ID", "YayinTip_Adi", yayin.YayinTip_ID);
            ViewBag.Yazar_ID = new SelectList(db.Yazar, "Yazar_ID", "Yazar_Adi", yayin.Yazar_ID);
            return View(yayin);
        }

        // GET: Yayin/Edit/5
        public ActionResult YayinEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yayin yayin = db.Yayin.Find(id);
            if (yayin == null)
            {
                return HttpNotFound();
            }
            ViewBag.YayinTip_ID = new SelectList(db.YayinTip, "YayinTip_ID", "YayinTip_Adi", yayin.YayinTip_ID);
            ViewBag.Yazar_ID = new SelectList(db.Yazar, "Yazar_ID", "Yazar_Adi", yayin.Yazar_ID);
            return View(yayin);
        }

        // POST: Yayin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YayinEdit([Bind(Include = "Yayin_ID,YayinTip_ID,Yayin_Baslik,Yayin_Foto,Yayin_Icerik,Yayin_Ozet,Yazar_ID,Etiket_ID,Yayin_Dosya,Yayin_Tarih,Slider_Baslik,Slider_Ozet")] Yayin yayin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yayin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("YayinIndex");
            }
            ViewBag.YayinTip_ID = new SelectList(db.YayinTip, "YayinTip_ID", "YayinTip_Adi", yayin.YayinTip_ID);
            ViewBag.Yazar_ID = new SelectList(db.Yazar, "Yazar_ID", "Yazar_Adi", yayin.Yazar_ID);
            return View(yayin);
        }

        // GET: Yayin/Delete/5
        public ActionResult YayinDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yayin yayin = db.Yayin.Find(id);
            if (yayin == null)
            {
                return HttpNotFound();
            }
            return View(yayin);
        }

        // POST: Yayin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult YayinDeleteConfirmed(int id)
        {
            Yayin yayin = db.Yayin.Find(id);
            db.Yayin.Remove(yayin);
            db.SaveChanges();
            return RedirectToAction("YayinIndex");
        }

        #endregion

        #region DUYURU

        // GET: Duyuru
        public ActionResult DuyuruIndex()
        {
            return View(db.Duyuru.ToList());
        }

        // GET: Duyuru/Details/5
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

        // GET: Duyuru/Create
        public ActionResult DuyuruCreate()
        {
            return View();
        }

        // POST: Duyuru/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DuyuruCreate([Bind(Include = "Duyuru_ID,Duyuru_Baslik,Duyuru_Icerik,Duyuru_Foto,Duyuru_Dosya, Duyuru_Tarih")] Duyuru duyuru, HttpPostedFileBase DuyuruFoto, HttpPostedFileBase DuyuruDosya)
        {
            //,Duyuru_Tarih
            if (ModelState.IsValid)
            {
                try
                {
                    if (DuyuruFoto.FileName != null && DuyuruDosya.FileName != null)
                    {
                        FileInfo fotoBilgisi = new FileInfo(DuyuruFoto.FileName);
                        string yeniFotoBilgisi = Guid.NewGuid().ToString("N") + fotoBilgisi.Extension;

                        FileInfo dosyaBilgisi = new FileInfo(DuyuruDosya.FileName);
                        string yeniDosyaBilgisi = Guid.NewGuid().ToString("N") + dosyaBilgisi.Extension;

                        DuyuruFoto.SaveAs(Server.MapPath("~/Content/Upload/Duyuru/Foto/" + yeniFotoBilgisi));
                        DuyuruDosya.SaveAs(Server.MapPath("~/Content/Upload/Duyuru/Dosya/" + yeniDosyaBilgisi));

                        duyuru.Duyuru_Foto = yeniFotoBilgisi;
                        duyuru.Duyuru_Dosya = yeniDosyaBilgisi;

                        db.Duyuru.Add(duyuru);
                        db.SaveChanges();
                        return RedirectToAction("DuyuruIndex");
                    }

                }
                catch (Exception)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Hello world!');</script>");
                    
                }
              
            }

            return View();
        }

        // GET: Duyuru/Edit/5
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

        // POST: Duyuru/Edit/5
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
                return RedirectToAction("DuyuruIndex");
            }
            return View(duyuru);
        }

        // GET: Duyuru/Delete/5
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

        // POST: Duyuru/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DuyuruDeleteConfirmed(int id)
        {
            Duyuru duyuru = db.Duyuru.Find(id);
            db.Duyuru.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("DuyuruIndex");
        }

        #endregion

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