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
    public class YayinlarController : Controller
    {
        private PesaDbEntities db = new PesaDbEntities();

        // GET: Yayinlar
        public ActionResult YayinIndex(string ID)
        {
            ViewBag.Message = ID;
            var yayin = db.Yayin.Include(y => y.YayinTip);
            return View(yayin.ToList());
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
