using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCServis.Areas.SYADMIN.DAL;
using MVCServis.Areas.SYADMIN.Models;

namespace MVCServis.Areas.SYADMIN.Controllers
{
    public class BankoGirisController : Controller
    {
        private SYADMINContext db = new SYADMINContext();

        // GET: SYADMIN/BankoGiris
        public ActionResult Index()
        {
            var bankoGirisler = db.BankoGirisler.Include(b => b.mtip);
            return View(bankoGirisler.ToList());
        }
        [HttpPost]
        public ActionResult Index( string text)
        {
            var ara = (from s in db.BankoGirisler
                       where s.takipNo.Contains(text)
                       select s).ToList();
            return View(ara);
        }
       

        // GET: SYADMIN/BankoGiris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankoGiris bankoGiris = db.BankoGirisler.Find(id);
            if (bankoGiris == null)
            {
                return HttpNotFound();
            }
            return View(bankoGiris);
        }

        // GET: SYADMIN/BankoGiris/Create
        public ActionResult Create()
        {
            ViewBag.mtipId = new SelectList(db.MusteriTipler, "Id", "MusteriTipi");
            ViewBag.garantiId = new SelectList(db.Garantiler, "ID", "GarantiAdi");
            ViewBag.TurunId = new SelectList(db.Urunler, "ID", "UrunKodu");
            return View();
        }

        // POST: SYADMIN/BankoGiris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,mtipId,musteriAdi,tcNo,Email,telEv,telIs,GSM,adres,servisGirisTarih,servisGirisSaat,seriNo,imei,musteriSikayet,Aciklama,takipNo,garantiId,TurunId")] BankoGiris bankoGiris)
        {
            if (ModelState.IsValid)
            {
                double numara;
                try
                {
                    numara = Convert.ToDouble((from s in db.BankoGirisler
                                                       orderby s.id descending
                                                       select s).FirstOrDefault().takipNo);
                }
                catch (Exception)
                {
                    numara = 0;
                }
                numara++;
                string num =  numara.ToString().PadLeft(7, '0');
                bankoGiris.takipNo = num;
                bankoGiris.servisGirisSaat = DateTime.Now;
                bankoGiris.servisGirisTarih = DateTime.Now;
                db.BankoGirisler.Add(bankoGiris);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mtipId = new SelectList(db.MusteriTipler, "Id", "MusteriTipi", bankoGiris.mtipId);
            ViewBag.garantiId = new SelectList(db.Garantiler, "ID", "GarantiAdi", bankoGiris.garantiId);
            ViewBag.TurunId = new SelectList(db.Urunler, "ID", "UrunKodu");
            return View(bankoGiris);
        }

        // GET: SYADMIN/BankoGiris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankoGiris bankoGiris = db.BankoGirisler.Find(id);
            if (bankoGiris == null)
            {
                return HttpNotFound();
            }
            ViewBag.mtipId = new SelectList(db.MusteriTipler, "Id", "MusteriTipi", bankoGiris.mtipId);
            ViewBag.garantiId = new SelectList(db.Garantiler, "ID", "GarantiAdi", bankoGiris.garantiId);
            ViewBag.TurunId = new SelectList(db.Urunler, "ID", "UrunKodu",bankoGiris.TurunId);
            return View(bankoGiris);
        }

        // POST: SYADMIN/BankoGiris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,mtipId,musteriAdi,tcNo,Email,telEv,telIs,GSM,adres,servisGirisTarih,servisGirisSaat,seriNo,imei,musteriSikayet,Aciklama,takipNo,garantiId,TurunId")] BankoGiris bankoGiris)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankoGiris).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mtipId = new SelectList(db.MusteriTipler, "Id", "MusteriTipi", bankoGiris.mtipId);
            ViewBag.garantiId = new SelectList(db.Garantiler, "ID", "GarantiAdi", bankoGiris.garantiId);
            ViewBag.TurunId = new SelectList(db.Urunler, "ID", "UrunKodu",bankoGiris.TurunId);
            return View(bankoGiris);
        }

        // GET: SYADMIN/BankoGiris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankoGiris bankoGiris = db.BankoGirisler.Find(id);
            if (bankoGiris == null)
            {
                return HttpNotFound();
            }
            return View(bankoGiris);
        }

        // POST: SYADMIN/BankoGiris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankoGiris bankoGiris = db.BankoGirisler.Find(id);
            db.BankoGirisler.Remove(bankoGiris);
            db.SaveChanges();
            return RedirectToAction("Index");
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
