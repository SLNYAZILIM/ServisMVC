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
    public class MusteriTipController : Controller
    {
        private SYADMINContext db = new SYADMINContext();

        // GET: SYADMIN/MusteriTip
        public ActionResult Index()
        {
            return View(db.MusteriTipler.ToList());
        }

        // GET: SYADMIN/MusteriTip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusteriTip musteriTip = db.MusteriTipler.Find(id);
            if (musteriTip == null)
            {
                return HttpNotFound();
            }
            return View(musteriTip);
        }

        // GET: SYADMIN/MusteriTip/Create
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

        // POST: SYADMIN/MusteriTip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MusteriTipi")] MusteriTip musteriTip)
        {
            if (ModelState.IsValid)
            {
                db.MusteriTipler.Add(musteriTip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musteriTip);
        }

        // GET: SYADMIN/MusteriTip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusteriTip musteriTip = db.MusteriTipler.Find(id);
            if (musteriTip == null)
            {
                return HttpNotFound();
            }
            return View(musteriTip);
        }

        // POST: SYADMIN/MusteriTip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MusteriTipi")] MusteriTip musteriTip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musteriTip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musteriTip);
        }

        // GET: SYADMIN/MusteriTip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusteriTip musteriTip = db.MusteriTipler.Find(id);
            if (musteriTip == null)
            {
                return HttpNotFound();
            }
            return View(musteriTip);
        }

        // POST: SYADMIN/MusteriTip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusteriTip musteriTip = db.MusteriTipler.Find(id);
            db.MusteriTipler.Remove(musteriTip);
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
