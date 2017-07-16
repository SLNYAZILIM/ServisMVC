using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCServis.Areas.SYADMIN.Models;
using System.Data.Entity;
using MVCServis.Areas.SYADMIN.DAL;
using System.Web.Security;

namespace MVCServis.Areas.SYADMIN.Controllers
{
    public class HomeController : Controller
    {
        SYADMINContext db = new SYADMINContext();
        bool vr = false;
        int tasi = 0;
        string tasist = "";
        // GET: SYADMIN/Home
        public ActionResult Index()
        {
            if (Session["Kullanici"] == null)
            {
                RedirectToAction("Giris","Home");
            }
            return View();
        }
        public ActionResult Giris()
        {
            Session.Abandon();
            return View();
        }
        [HttpPost]
        public ActionResult Giris(string mail, string sifre)
        {

            //var grs = (from s in db.Kullanicilar
            //           select new { s.ID, s.kullaniciAdi, s.email, s.sifre, s.YetkiId }).ToList();
            //foreach (var k in grs)
            //{
            //    if (k.email == mail && k.sifre == sifre)
            //    {
            //        vr = true;
            //        tasi = k.YetkiId;
            //        tasist=k.email;
            //    }
            //}
            //if (vr == true)
            //{
            //    Session["Kullanici"] = query.email;
            //    return RedirectToAction("Index", "Home");
            //}

            var query = (from user in db.Kullanicilar
                         where user.email == mail &&
                         user.sifre == sifre
                         select user).FirstOrDefault();
            if (query != null)
            {
                Session["Kullanici"] = query.email;
                Session["Yetki"] = query.YetkiId;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Giris", "Home");
            }

        }
        public ActionResult Kullanici()
        {
            return View();
        }
    }
}