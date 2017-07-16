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
using MVCServis.Areas.SYADMIN.Unit;

namespace MVCServis.Areas.SYADMIN.Controllers
{
    public class YetkisController : baseController
    {
        private SYADMINContext db = new SYADMINContext();

        // GET: SYADMIN/Yetkis
        public ActionResult Index()
        {
            return View(db.Yetkiler.ToList());
        }

        // GET: SYADMIN/Yetkis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yetki yetki = db.Yetkiler.Find(id);
            if (yetki == null)
            {
                return HttpNotFound();
            }
            return View(yetki);
        }

        // GET: SYADMIN/Yetkis/Create
        public ActionResult Create()
        {
            if (Session["Yetki"] != null && Session["Yetki"].ToString() == "1")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: SYADMIN/Yetkis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,yetkiadi")] Yetki yetki)
        {
            if (ModelState.IsValid)
            {
                db.Yetkiler.Add(yetki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yetki);
        }

        // GET: SYADMIN/Yetkis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yetki yetki = db.Yetkiler.Find(id);
            if (yetki == null)
            {
                return HttpNotFound();
            }
            return View(yetki);
        }

        // POST: SYADMIN/Yetkis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,yetkiadi")] Yetki yetki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yetki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yetki);
        }

        // GET: SYADMIN/Yetkis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yetki yetki = db.Yetkiler.Find(id);
            if (yetki == null)
            {
                return HttpNotFound();
            }
            return View(yetki);
        }

        // POST: SYADMIN/Yetkis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yetki yetki = db.Yetkiler.Find(id);
            db.Yetkiler.Remove(yetki);
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
