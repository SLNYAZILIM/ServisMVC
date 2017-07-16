using MVCServis.TstServ1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCServis.Controllers
{
    public class ServislerController : Controller
    {
        
        // GET: Servisler
        public ActionResult Index()
        {

            CaferServis.CaferSoapClient cfr = new CaferServis.CaferSoapClient();
            TestSoapClient tst = new TestSoapClient();
            ViewBag.Test = cfr.HelloWorld();
            return View(cfr.tumDersler());
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult TcSorgu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TcSorgu(long TCKimlikNo, string Ad, string Soyad,int DogumYili)
        {
            TcSorgula.KPSPublicSoapClient tcs = new TcSorgula.KPSPublicSoapClient();
            bool durum = false;
            try
            {
                durum = tcs.TCKimlikNoDogrula(TCKimlikNo, Ad, Soyad, DogumYili);
                ViewBag.Durum = "Kimliğiniz doğrulandı.";
                ModelState.Clear();
            }
            catch (Exception)
            {
                ViewBag.Durum = "Kimliğiniz doğrulanamadı.Bilgilerinizikontrol edin.";
                ModelState.Remove("TCKimlikNo");
                ModelState.Remove("Ad");
                ModelState.Remove("Soyad");
                ModelState.Remove("DogumYili");
                
            }
            return View();
        }

    }
}