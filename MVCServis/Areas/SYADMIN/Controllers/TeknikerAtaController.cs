using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCServis.Areas.SYADMIN.DAL;
using MVCServis.Areas.SYADMIN.Models;

namespace MVCServis.Areas.SYADMIN.Controllers
{
    
    public class TeknikerAtaController : Controller
    {
        public SYADMINContext DB = new SYADMINContext();
        // GET: SYADMIN/TeknikerAta
        public ActionResult Index(int? id ,int? Bid)
        {
            
            if (Bid!=null)
            {
                Session["a"] = Bid.Value;
                TempData["b"] = Bid.Value;//1. tekniker atama için ilk olarak listele sayfasından seçilen kaydı tempdataya atıyoruz.Tempdata çalışma pirensibi sistem kapanmadan ve üzerine yazılmadan aynı datayı taşıması.
            }
            if (id == null)
            {              
                
                return View(DB.Teknikerler.ToList());
            }
            
            var teknik = (from s in DB.Teknikerler
                          where s.id == id
                          select s).FirstOrDefault();
            ViewBag.tek = teknik.teknikerAdi;    
            int sayi = (from s in DB.Teknikerler
                    where s.id == id
                    select s.teknikerIsYuk).FirstOrDefault();
            sayi++;
            int a = Convert.ToInt32(TempData["b"]);
            BankoGiris bnk = DB.BankoGirisler.First(s => s.id ==a );
            bnk.TeknikerAdi = ViewBag.tek;
            tekniker guncelle = DB.Teknikerler.First(u => u.id == id);
            guncelle.teknikerIsYuk = sayi;
            DB.SaveChanges();
            //return View(DB.Teknikerler.ToList());
            return RedirectToAction("Listele");
        }
        
        public ActionResult Listele()
        {
            return View(DB.BankoGirisler.Where(x=>x.TeknikerAdi==null).ToList());//2. listelede tekniker atanmamış kayıtların gelmesini sağlıyoruz.(teknikServiscontroller a git)
        }
        [HttpPost]
        public ActionResult Listele(int a)
        {
            int ara = (from s in DB.BankoGirisler
                       where s.id==a
                       select s.id).FirstOrDefault();
            return View(ara);
        }

    }
}