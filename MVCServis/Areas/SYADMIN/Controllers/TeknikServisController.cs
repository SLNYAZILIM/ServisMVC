using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCServis.Areas.SYADMIN.DAL;
using MVCServis.Areas.SYADMIN.Models;

namespace MVCServis.Areas.SYADMIN.Controllers
{
    public class TeknikServisController : Controller
    {
        private SYADMINContext DB = new SYADMINContext();
        // GET: SYADMIN/TeknikServis
        public ActionResult Index()
        {
            return View(DB.TServisler.ToList());
        }
        public ActionResult Kaydet(int? id)
        {
            ViewBag.DurumId = new SelectList(DB.Durumlar, "ID", "DurumKodu");
            ViewBag.BelirtiId = new SelectList(DB.Belirtiler, "ID", "BelirtiKodu");
            ViewBag.OnarimId = new SelectList(DB.Onarimlar, "ID", "OnarimKodu");
            ViewBag.ArizaId = new SelectList(DB.Arizalar, "ID", "ArizaKodu");
            ViewBag.UrunId = new SelectList(DB.Urunler, "ID", "UrunKodu");
            if (id==null)
            {
                
                return View(); 
            }
            else
            {
                var bul = (from s in DB.BankoGirisler
                           where s.id == id
                           select new { s.id, s.Aciklama, s.seriNo, s.imei,s.takipNo,s.musteriSikayet,s.Turun.UrunKodu,s.TeknikerAdi }).FirstOrDefault();
                //3.yukarı teknikerAdini ekle
                ViewBag.Aciklama = bul.Aciklama;
                ViewBag.SeriNo = bul.seriNo;
                ViewBag.TakipNo = bul.takipNo;
                ViewBag.Imei = bul.imei;
                ViewBag.Sikayet = bul.musteriSikayet;
                ViewBag.UrunKodu = bul.UrunKodu;
                ViewBag.TekAdi = bul.TeknikerAdi;//4.viewbag tekniker adi ekle
                var tid = (from k in DB.Teknikerler
                           where k.teknikerAdi == bul.TeknikerAdi
                           select k).FirstOrDefault();
                ViewBag.TekKodu = tid.teknikerNo;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(TeknikServisGiris teknikServisGiris)
        {
            if (ModelState.IsValid)
            {
                DB.TServisler.Add(teknikServisGiris);
                DB.SaveChanges();
                return RedirectToAction("Listele");
            }
            ViewBag.DurumId = new SelectList(DB.Durumlar, "ID", "DurumKodu", teknikServisGiris.DurumId);
            ViewBag.BelirtiId = new SelectList(DB.Belirtiler, "ID", "BelirtiKodu", teknikServisGiris.BelirtiId);
            ViewBag.OnarimId = new SelectList(DB.Onarimlar, "ID", "OnarimKodu", teknikServisGiris.OnarimId);
            ViewBag.ArizaId = new SelectList(DB.Arizalar, "ID", "ArizaKodu", teknikServisGiris.ArizaId);

            return View();
        }
        public ActionResult Listele()
        {
            return View(DB.BankoGirisler.Where(x=>x.TeknikerAdi!=null).ToList());
        }
    }
}