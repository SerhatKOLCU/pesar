using PESA.Models;
using reCAPTCHA.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PESA.Controllers
{
    public class HomeController : Controller
    {
        private PesaDbEntities db = new PesaDbEntities();

        public ActionResult Index(string ID)
        {
            ViewBag.Message = ID;
            var yayin = db.Yayin;
            return View(yayin.ToList());

        }

        public ActionResult News()
        {
            ViewBag.Message = "Haberler";

            return View();
        }

        public ActionResult Staff()
        {
            ViewBag.Message = "Kadromuz";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidator]
        public ActionResult Login(FormCollection frm, bool captchaValid)
        {
            PesaDbEntities obj = new PesaDbEntities();
            var userName = frm["Username"];
            var password = frm["Password"];

            var isUserValid = obj.Kullanici.Where(x => x.Kullanici_Adli == userName && x.Kullanici_Parola == password).FirstOrDefault();

            if (isUserValid != null && captchaValid)
            {
                Session["UserSession"] = isUserValid.Kullanici_ID + " | " + isUserValid.Kullanici_Adli;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["ErrorMessage"] = "Hatalı giriş yaptınız! Lütfen bilgilerinizi kontol edip tekrar deneyiniz.";
                return View();
            }

        }
        
    }
}