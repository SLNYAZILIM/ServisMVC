using MVCServis.Areas.SYADMIN.DAL;
using MVCServis.Areas.SYADMIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCServis.Controllers
{
    public class HomeController : Controller
    {
        SYADMINContext DB = new SYADMINContext();
        public ActionResult Index()
        {
            ViewBag.Cikis = "Visible";
            ViewBag.Giris = "Hidden";
            UserG usr = (UserG)Session["userbilgi"];
            if (usr==null)
            {
                ViewBag.usrAdi = "Giriş yapmalısın.";
                ViewBag.Cikis = "Visible";
                ViewBag.Giris = "Hidden";
                ViewBag.Foto = "/Yuklemeler/UserFoto/bos.png";
            }
            else
            {
                ViewBag.usrAdi = usr.adi;
                ViewBag.usrEmail = usr.email;
                ViewBag.Cikis = "Hidden";
                ViewBag.Giris = "Visible";
                if (usr.foto==null)
                {
                    ViewBag.Foto = "/Yuklemeler/UserFoto/bos.png";
                }
                else
                {
                    ViewBag.Foto = usr.foto;
                }
            }
            var yrm = (from s in DB.UserYorumlar
                       select s).OrderByDescending(x => x.tarih).OrderByDescending(y=>y.ID).Take(3).ToList();
            if (yrm.Count.ToString() !=null)
            {
                ViewBag.Yorum1 = yrm.ElementAt(0).yorum;
                ViewBag.Adi1 = yrm.ElementAt(0).userAdi;
                ViewBag.Resim1 = yrm.ElementAt(0).foto;
                ViewBag.Tarih1 = yrm.ElementAt(0).tarih;

                ViewBag.Yorum2 = yrm.ElementAt(1).yorum;
                ViewBag.Adi2 = yrm.ElementAt(1).userAdi;
                ViewBag.Resim2 = yrm.ElementAt(1).foto;
                ViewBag.Tarih2 = yrm.ElementAt(1).tarih;

                ViewBag.Yorum3 = yrm.ElementAt(2).yorum;
                ViewBag.Adi3 = yrm.ElementAt(2).userAdi;
                ViewBag.Resim3 = yrm.ElementAt(2).foto;
                ViewBag.Tarih3 = yrm.ElementAt(2).tarih; 
            }
            else
            {
                ViewBag.Yorum1 = "";
                ViewBag.Adi1 = "";
                ViewBag.Resim1 = "/Yuklemeler/UserFoto/bos.png";
                ViewBag.Tarih1 = "";

                ViewBag.Yorum2 = "";
                ViewBag.Adi2 = "";
                ViewBag.Resim2 = "/Yuklemeler/UserFoto/bos.png";
                ViewBag.Tarih2 = "";

                ViewBag.Yorum3 = "";
                ViewBag.Adi3 = "";
                ViewBag.Resim3 = "/Yuklemeler/UserFoto/bos.png";
                ViewBag.Tarih3 = "";
            }

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
        public ActionResult Mobilephones()
        {
            return View();
        }
        public ActionResult Tablets()
        {
            return View();
        }
        public ActionResult Accessories()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
    }
}