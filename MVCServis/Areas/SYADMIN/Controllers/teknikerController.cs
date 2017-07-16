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
    public class teknikerController : Controller
    {
        private SYADMINContext db = new SYADMINContext();

        // GET: SYADMIN/tekniker
        public ActionResult Index()
        {
            return View(db.Teknikerler.ToList());
        }

        // GET: SYADMIN/tekniker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tekniker tekniker = db.Teknikerler.Find(id);
            if (tekniker == null)
            {
                return HttpNotFound();
            }
            return View(tekniker);
        }

        // GET: SYADMIN/tekniker/Create
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

        // POST: SYADMIN/tekniker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,teknikerNo,teknikerAdi")] tekniker tekniker)
        {
            if (ModelState.IsValid)
            {
                db.Teknikerler.Add(tekniker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tekniker);
        }

        // GET: SYADMIN/tekniker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tekniker tekniker = db.Teknikerler.Find(id);
            if (tekniker == null)
            {
                return HttpNotFound();
            }
            return View(tekniker);
        }

        // POST: SYADMIN/tekniker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,teknikerNo,teknikerAdi")] tekniker tekniker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tekniker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tekniker);
        }

        // GET: SYADMIN/tekniker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tekniker tekniker = db.Teknikerler.Find(id);
            if (tekniker == null)
            {
                return HttpNotFound();
            }
            return View(tekniker);
        }

        // POST: SYADMIN/tekniker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tekniker tekniker = db.Teknikerler.Find(id);
            db.Teknikerler.Remove(tekniker);
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
