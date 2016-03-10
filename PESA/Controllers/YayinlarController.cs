using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PESA.Controllers
{
    public class YayinlarController : Controller
    {
        // GET: Yayinlar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult YayinPostLayout()
        {
            return View();
        }

        // GET: Analiz
        public ActionResult Analiz()
        {
            return View();
        }

        // GET: Gorus
        public ActionResult Gorus()
        {
            return View();
        }

        // GET: Rapor
        public ActionResult Rapor()
        {
            return View();
        }

        // GET: EkonomiBulteni
        public ActionResult EkonomiBulteni()
        {
            return View();
        }
    }
}