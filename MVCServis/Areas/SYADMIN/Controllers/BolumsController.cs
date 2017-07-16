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
    public class BolumsController : Controller
    {
        private SYADMINContext db = new SYADMINContext();

        // GET: SYADMIN/Bolums
        public ActionResult Index()
        {
            return View(db.Bolumler.ToList());
        }

        // GET: SYADMIN/Bolums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolum bolum = db.Bolumler.Find(id);
            if (bolum == null)
            {
                return HttpNotFound();
            }
            return View(bolum);
        }

        // GET: SYADMIN/Bolums/Create
        public ActionResult Create()
        {
            if (Session["Yetki"] != null && Session["Yetki"].ToString()=="1")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
            
        }

        // POST: SYADMIN/Bolums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BolumAdi")] Bolum bolum)
        {
            if (ModelState.IsValid)
            {
                db.Bolumler.Add(bolum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bolum);
        }

        // GET: SYADMIN/Bolums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolum bolum = db.Bolumler.Find(id);
            if (bolum == null)
            {
                return HttpNotFound();
            }
            return View(bolum);
        }

        // POST: SYADMIN/Bolums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BolumAdi")] Bolum bolum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bolum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bolum);
        }

        // GET: SYADMIN/Bolums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolum bolum = db.Bolumler.Find(id);
            if (bolum == null)
            {
                return HttpNotFound();
            }
            return View(bolum);
        }

        // POST: SYADMIN/Bolums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bolum bolum = db.Bolumler.Find(id);
            db.Bolumler.Remove(bolum);
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
