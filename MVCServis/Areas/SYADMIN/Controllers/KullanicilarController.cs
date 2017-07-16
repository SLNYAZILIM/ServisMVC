using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVCServis.Areas.SYADMIN.Models;
using MVCServis.Areas.SYADMIN.DAL;
using System.Net;

namespace MVCServis.Areas.SYADMIN.Controllers
{
    public class KullanicilarController : Controller
    {
        SYADMINContext db = new SYADMINContext();
        // GET: SYADMIN/Kullanicilar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Liste()
        {

            return View(db.Kullanicilar.ToList());
        }
        public ActionResult kaydet()
        {
            if (Session["Yetki"] != null && Session["Yetki"].ToString() == "1")
            {
                ViewBag.date2 = DateTime.Now.ToShortDateString();
                ViewBag.BolumId = new SelectList(db.Bolumler, "ID", "BolumAdi");
                ViewBag.yetkiId = new SelectList(db.Yetkiler, "ID", "yetkiadi");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult kaydet(Kullanicilar kullaniclar)
        {
            db.Kullanicilar.Add(kullaniclar);
            db.SaveChanges();
            return RedirectToAction("Giris", "Home");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanicilar kullanicilar = db.Kullanicilar.Find(id);
            if (kullanicilar == null)
            {
                return HttpNotFound();
            }
            ViewBag.BolumId = new SelectList(db.Bolumler, "ID", "BolumAdi", kullanicilar.BolumId);
            ViewBag.YetkiId = new SelectList(db.Yetkiler, "ID", "yetkiadi", kullanicilar.YetkiId);
            return View(kullanicilar);
        }

        // POST: SYADMIN/Kullanicilar2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,email,kullaniciAdi,sifre,BolumId,YetkiId,oluşturmaTarihi")] Kullanicilar kullanicilar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanicilar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Liste");
            }
            ViewBag.BolumId = new SelectList(db.Bolumler, "ID", "BolumAdi", kullanicilar.BolumId);
            ViewBag.YetkiId = new SelectList(db.Yetkiler, "ID", "yetkiadi", kullanicilar.YetkiId);
            return View(kullanicilar);
        }

        // GET: SYADMIN/Kullanicilar2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanicilar kullanicilar = db.Kullanicilar.Find(id);
            if (kullanicilar == null)
            {
                return HttpNotFound();
            }
            return View(kullanicilar);
        }

        // POST: SYADMIN/Kullanicilar2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kullanicilar kullanicilar = db.Kullanicilar.Find(id);
            db.Kullanicilar.Remove(kullanicilar);
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanicilar kullanicilar = db.Kullanicilar.Find(id);
            if (kullanicilar == null)
            {
                return HttpNotFound();
            }
            return View(kullanicilar);
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