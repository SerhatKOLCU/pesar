﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PESA.Models;
using System.IO;
using PagedList;
using PagedList.Mvc;


namespace PESA.Controllers
{
    public class AdminController : Controller
    {
        private PesaDbEntities db = new PesaDbEntities();

        // GET: Admin
        public ActionResult Index()
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
            {
                return View();
            }
        }

        public ActionResult PermissionDenied()
        {
            if (Session["UserSession"] != null)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Exit()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


        #region YAYIN

        // GET: Yayins
        public ActionResult YayinIndex(string ID, int? sayfaNo)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
            {
                ViewBag.Message = ID;
                int _sayfaNo = sayfaNo ?? 1;
                var yayin = db.Yayin.Include(y => y.YayinTip);
                return View(yayin.ToList().ToPagedList<Yayin>(_sayfaNo,10));
            }
        }


        // GET: Yayins/Details/5
        public ActionResult YayinDetails(int? id)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
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
        }

        // GET: Yayins/Create
        public ActionResult YayinCreate()
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
            {
                ViewBag.YayinTip_ID = new SelectList(db.YayinTip, "YayinTip_ID", "YayinTip_Adi");
                return View();
            }
        }

        // POST: Yayins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult YayinCreate([Bind(Include = "Yayin_ID,YayinTip_ID,Yayin_Baslik,Yayin_Foto,Yayin_Icerik,Yayin_Ozet,YayinEtiket,Yayin_Yazar,Yayin_Dosya,Yayin_Tarih")] Yayin yayin, HttpPostedFileBase YayinFoto, HttpPostedFileBase YayinDosya)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
            {
                if (ModelState.IsValid)
                {

                    if (YayinFoto.FileName != null && YayinDosya.FileName != null)
                    {


                        FileInfo fotoBilgisi = new FileInfo(YayinFoto.FileName);
                        string yeniFotoBilgisi = Guid.NewGuid().ToString("n") + fotoBilgisi.Extension;



                        FileInfo dosyaBilgisi = new FileInfo(YayinDosya.FileName);
                        string yeniDosyaBilgisi = Guid.NewGuid().ToString("n") + dosyaBilgisi.Extension;

                        YayinFoto.SaveAs(Server.MapPath("~/Content/Upload/Yayin/Foto/" + yeniFotoBilgisi));
                        YayinDosya.SaveAs(Server.MapPath("~/Content/Upload/Yayin/Dosya/" + yeniDosyaBilgisi));

                        yayin.Yayin_Foto = yeniFotoBilgisi;
                        yayin.Yayin_Dosya = yeniDosyaBilgisi;


                        db.Yayin.Add(yayin);
                        db.SaveChanges();
                        return RedirectToAction("YayinIndex");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Lütfen yayin için düzgün veri girin.");
                        return View(yayin);
                    }

                }

                ViewBag.YayinTip_ID = new SelectList(db.YayinTip, (Request.QueryString["YayinTip_ID"].ToString()), "YayinTip_Adi", yayin.YayinTip_ID);

                return View(yayin);
            }
        }

        // GET: Yayins/Edit/5
        public ActionResult YayinEdit(int? id)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
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
                return View(yayin);
            }
        }

        // POST: Yayins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult YayinEdit([Bind(Include = "Yayin_ID,YayinTip_ID,Yayin_Baslik,Yayin_Foto,Yayin_Icerik,Yayin_Ozet,YayinEtiket,Yayin_Yazar,Yayin_Dosya,Yayin_Tarih")] Yayin yayin, HttpPostedFileBase YayinFoto, HttpPostedFileBase YayinDosya)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (YayinFoto.FileName != null && YayinDosya.FileName != null)
                    {


                        FileInfo fotoBilgisi = new FileInfo(YayinFoto.FileName);
                        string yeniFotoBilgisi = Guid.NewGuid().ToString("n") + fotoBilgisi.Extension;



                        FileInfo dosyaBilgisi = new FileInfo(YayinDosya.FileName);
                        string yeniDosyaBilgisi = Guid.NewGuid().ToString("n") + dosyaBilgisi.Extension;

                        YayinFoto.SaveAs(Server.MapPath("~/Content/Upload/Yayin/Foto/" + yeniFotoBilgisi));
                        YayinDosya.SaveAs(Server.MapPath("~/Content/Upload/Yayin/Dosya/" + yeniDosyaBilgisi));

                        yayin.Yayin_Foto = yeniFotoBilgisi;
                        yayin.Yayin_Dosya = yeniDosyaBilgisi;


                        db.Entry(yayin).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Lütfen yayin için düzgün veri girin.");
                        return View(yayin);
                    }
                    //db.Entry(yayin).State = EntityState.Modified;
                    //db.SaveChanges();
                    //return RedirectToAction("Index");
                }
                ViewBag.YayinTip_ID = new SelectList(db.YayinTip, "YayinTip_ID", "YayinTip_Adi", yayin.YayinTip_ID);
                return View(yayin);
            }
        }

        // GET: Yayins/Delete/5
        public ActionResult YayinDelete(int? id)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
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
        }

        // POST: Yayins/Delete/5
        [HttpPost, ActionName("YayinDelete")]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult YayinDeleteConfirmed(int id)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
            {
                Yayin yayin = db.Yayin.Find(id);
                db.Yayin.Remove(yayin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        #endregion

        #region DUYURU

        // GET: Duyuru
        public ActionResult DuyuruIndex(int? sayfaNo)
        {

            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
            {
                int _sayfaNo = sayfaNo ?? 1;
                return View(db.Duyuru.ToList().ToPagedList<Duyuru>(_sayfaNo, 10));
            }

        }

        // GET: Duyuru/Details/5
        public ActionResult DuyuruDetails(int? id)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
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

        }

        // GET: Duyuru/Create
        public ActionResult DuyuruCreate()
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else { return View(); }

        }

        // POST: Duyurus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult DuyuruCreate([Bind(Include = "Duyuru_ID,Duyuru_Baslik,Duyuru_Icerik,Duyuru_Foto,Duyuru_Dosya, Duyuru_Tarih")] Duyuru duyuru, HttpPostedFileBase DuyuruFoto, HttpPostedFileBase DuyuruDosya)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
            {
                if (ModelState.IsValid)
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
                    else
                    {
                        ModelState.AddModelError("", "Lütfen duyuru için düzgün veri girin.");
                        return View(duyuru);
                    }
                }

                return View(duyuru);
            }
        }

        // GET: Duyuru/Edit/5
        public ActionResult DuyuruEdit(int? id)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
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

        }

        // POST: Duyuru/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult DuyuruEdit([Bind(Include = "Duyuru_ID,Duyuru_Baslik,Duyuru_Icerik,Duyuru_Foto,Duyuru_Dosya,Duyuru_Tarih")] Duyuru duyuru, HttpPostedFileBase DuyuruFoto, HttpPostedFileBase DuyuruDosya)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
            {
                if (ModelState.IsValid)
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

                        db.Entry(duyuru).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("DuyuruIndex");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Lütfen duyuru için düzgün veri girin.");
                        return View(duyuru);
                    }
                }
                return View(duyuru);
            }

        }

        // GET: Duyuru/Delete/5
        public ActionResult DuyuruDelete(int? id)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
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

        }

        // POST: Duyuru/Delete/5
        [HttpPost, ActionName("DuyuruDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DuyuruDeleteConfirmed(int id)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("PermissionDenied", "Admin");
            }
            else
            {
                Duyuru duyuru = db.Duyuru.Find(id);
                db.Duyuru.Remove(duyuru);
                db.SaveChanges();
                return RedirectToAction("DuyuruIndex");
            }

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