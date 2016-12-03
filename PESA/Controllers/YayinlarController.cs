using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PESA.Models;
using PagedList;
using PagedList.Mvc;

namespace PESA.Controllers
{
    public class YayinlarController : Controller
    {
        private PesaDbEntities db = new PesaDbEntities();

        // GET: Yayinlar
        public ActionResult YayinIndex(string ID, int? sayfaNo)
        {
            ViewBag.Message = ID;
            int _sayfaNo = sayfaNo ?? 1;
            var yayin = db.Yayin.Include(y => y.YayinTip).ToList().ToPagedList<Yayin>(_sayfaNo,10);
            return View(yayin);
        }

        // GET Filtreli Yayin (Yazar, Etiket)
        public ActionResult YayinFiltre(string filtre, int? sayfaNo)
        {
            ViewBag.Filtre = filtre;
            int _sayfaNo = sayfaNo ?? 1;
            var filtreliYayin = db.Yayin.Where(f => f.YayinEtiket.Contains(filtre) || f.Yayin_Yazar.Contains(filtre)).ToList().ToPagedList<Yayin>(_sayfaNo, 10);
            return View(filtreliYayin);
        }

        // GET: Yayinlar/Details/5
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
        
        // GET: Duyuru
        public ActionResult DuyuruIndex(int? sayfaNo)
        {
            int _sayfaNo = sayfaNo ?? 1;
            return View(db.Duyuru.ToList().ToPagedList<Duyuru>(_sayfaNo,10));
        }

        // GET: Yayinlar/Details/5
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
        // AnaSayfa Duyurular Partial
        public PartialViewResult PartialDuyuru()
        {
            return PartialView(db.Duyuru.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public PartialViewResult YazarSonYayinlar(string yazar)
        {
            return PartialView(db.Yayin.Where(y => y.Yayin_Yazar.Contains(yazar)).ToList());
        }
    }
}
