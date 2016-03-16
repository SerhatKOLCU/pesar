using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PESA.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AnalizEkle()
        {
            return View();
        }
        public ActionResult AnalizListele()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GorusEkle()
        {
            return View();
        }
        public ActionResult GorusListele()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RaporEkle()
        {
            return View();
        }
        public ActionResult RaporListele()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BultenEkle()
        {
            return View();
        }
        public ActionResult BultenListele()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SlideEkle()
        {
            return View();
        }
        public ActionResult SlideListele()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DuyuruEkle()
        {
            return View();
        }
        public ActionResult DuyuruListele()
        {
            return View();
        }
    }
}