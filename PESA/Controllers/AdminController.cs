using PESA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PESA.Controllers
{
    public class AdminController : Controller
    {
        PesaDbEntities1 ent = new PesaDbEntities1();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region YAYIN LİSTELE
        public ActionResult YayinListele()
        {
            var listeleYayin = ent.Yayin.ToList();
            return View(listeleYayin);
        }
        #endregion

        #region YAYIN EKLE
        public ActionResult YayinEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YayinEkle(Yayin paramYayin)
        {
            Yayin createYayin = new Yayin();
            createYayin.Yayin_ID = paramYayin.Yayin_ID;
            createYayin.YayinTip_ID = paramYayin.YayinTip_ID;
            createYayin.Yayin_Baslik = paramYayin.Yayin_Baslik;
            createYayin.Yayin_Foto = paramYayin.Yayin_Foto;
            createYayin.Yayin_Icerik = paramYayin.Yayin_Icerik;
            createYayin.Yayin_Ozet = paramYayin.Yayin_Ozet;
            createYayin.Yazar_ID = paramYayin.Yazar_ID;
            createYayin.Etiket_ID = paramYayin.Etiket_ID;
            createYayin.Yayin_Dosya = paramYayin.Yayin_Dosya;
            createYayin.Yayin_Tarih = paramYayin.Yayin_Tarih;
            createYayin.Slider_Baslik = paramYayin.Slider_Baslik;
            createYayin.Slider_Ozet = paramYayin.Slider_Ozet;

            ent.Yayin.Add(createYayin);
            ent.SaveChanges();
            ViewBag.Message = "Yayın başarıyla eklendi.";
            return View();
        }
        #endregion

        #region YAYIN DÜZENLE
        public ActionResult YayinDuzenle(int? id)
        {
            Yayin editYayin = ent.Yayin.Find(id);
            return View(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YayinDuzenle([Bind(Include = "Yayin_ID, YayinTip_ID, Yayin_Baslik, Yayin_Foto, Yayin_Icerik, Yayin_Ozet, Yazar_ID, Etiket_ID, Yayin_Dosya, Yayin_Tarih, Slider_Baslik, Slider_Ozet ")] Yayin paramYayin)
        {
            if (ModelState.IsValid)
            {
                ent.Entry(paramYayin).State = EntityState.Modified;
                ent.SaveChanges();
                return RedirectToAction("YayinListele", "Admin");
            }
            return View(paramYayin);
        }
        #endregion


        #region // Duyuru
        
        public ActionResult Duyuru()
        {
            var Duyuru = ent.Duyuru.ToList();
            return View(Duyuru);
        }

        public ActionResult DuyuruEkle()
        {
            return View();
        }

        public ActionResult DuyuruDuzenle(int DuyuruID)
        {
            var _duyuruDuzenle = ent.Duyuru.Where(x => x.Duyuru_ID == DuyuruID).FirstOrDefault();
            return View(_duyuruDuzenle);
        }

        public ActionResult DuyuruSil(int DuyuruID)
        {
            try
            {
                ent.Duyuru.Remove(ent.Duyuru.First(d => d.Duyuru_ID == DuyuruID));
                ent.SaveChanges();
                return RedirectToAction("Duyuru", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }

        [HttpPost]
        public ActionResult DuyuruEkle(Duyuru d)
        {
            try
            {
                Duyuru _duyuru = new Duyuru();
                _duyuru.Duyuru_Baslik = d.Duyuru_Baslik;
                _duyuru.Duyuru_Icerik = d.Duyuru_Icerik;
                _duyuru.Duyuru_Foto = d.Duyuru_Foto;
                _duyuru.Duyuru_Dosya = d.Duyuru_Dosya;
                _duyuru.Duyuru_Tarih = DateTime.Now;

                ent.Duyuru.Add(_duyuru);
                ent.SaveChanges();
                return RedirectToAction("Duyuru", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }

        [HttpPost]
        public ActionResult DuyuruDuzenle(Duyuru dyr)
        {
            try
            {
                var _duyuruDuzenle = ent.Duyuru.Where(x => x.Duyuru_ID == dyr.Duyuru_ID).FirstOrDefault();
                _duyuruDuzenle.Duyuru_Baslik = dyr.Duyuru_Baslik;
                _duyuruDuzenle.Duyuru_Icerik = dyr.Duyuru_Icerik;
                _duyuruDuzenle.Duyuru_Foto = dyr.Duyuru_Foto;
                _duyuruDuzenle.Duyuru_Dosya = dyr.Duyuru_Dosya;

                ent.SaveChanges();
                return RedirectToAction("Duyuru", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }

        #endregion


    }
}


/////  ANALİZ CRUD  /////
/*
        #region ANALİZ LİSTELE
        public ActionResult AnalizListele()
        {
            var listeleAnaliz = ent.Yayin.ToList();
            return View(listeleAnaliz);
        }
        #endregion

        #region ANALİZ EKLE
        public ActionResult AnalizEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AnalizEkle(Yayin paramAnaliz)
        {
            Yayin createAnaliz = new Yayin();
            createAnaliz.Yayin_ID = paramAnaliz.Yayin_ID;
            createAnaliz.YayinTip_ID = 1;
            createAnaliz.Yayin_Baslik = paramAnaliz.Yayin_Baslik;
            createAnaliz.Yayin_Foto = paramAnaliz.Yayin_Foto;
            createAnaliz.Yayin_Icerik = paramAnaliz.Yayin_Icerik;
            createAnaliz.Yayin_Ozet = paramAnaliz.Yayin_Ozet;
            createAnaliz.Yazar_ID = paramAnaliz.Yazar_ID;
            createAnaliz.Etiket_ID = paramAnaliz.Etiket_ID;
            createAnaliz.Yayin_Dosya = paramAnaliz.Yayin_Dosya;
            createAnaliz.Yayin_Tarih = paramAnaliz.Yayin_Tarih;
            createAnaliz.Slider_Baslik = paramAnaliz.Slider_Baslik;
            createAnaliz.Slider_Ozet = paramAnaliz.Slider_Ozet;

            ent.Yayin.Add(createAnaliz);
            ent.SaveChanges();
            ViewBag.Message = "Analiz başarıyla eklendi.";
            return View();
        }
        #endregion

        #region ANALİZ DÜZENLE
        public ActionResult AnalizDuzenle(int? id)
        {
            Yayin editAnaliz = ent.Yayin.Find(id);
            return View(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnalizDuzenle([Bind(Include = "Yayin_ID, YayinTip_ID, Yayin_Baslik, Yayin_Foto, Yayin_Icerik, Yayin_Ozet, Yazar_ID, Etiket_ID, Yayin_Dosya, Yayin_Tarih, Slider_Baslik, Slider_Ozet ")] Yayin paramAnaliz)
        {
            if (ModelState.IsValid)
            {
                ent.Entry(paramAnaliz).State = EntityState.Modified;
                ent.SaveChanges();
                return RedirectToAction("AnalizListele", "Admin");
            }
            return View(paramAnaliz);
        }
        #endregion

*/
