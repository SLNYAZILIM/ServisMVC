using MVCServis.Areas.SYADMIN.DAL;
using MVCServis.Areas.SYADMIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCServis.Controllers
{
    public class UserYorumController : Controller
    {
        public SYADMINContext DB = new SYADMINContext();
        // GET: UserYorum
        public ActionResult Index()
        {
            UserG usr = (UserG)Session["userbilgi"];
            if (usr!=null)
            {
                ViewBag.userId = usr.ID;
                ViewBag.userAdi = usr.adi;
                ViewBag.tarih = DateTime.Now;                
                if (usr.foto == null)
                {
                    ViewBag.resim = "/Yuklemeler/UserFoto/bos.png";
                }
                else
                {
                    ViewBag.resim = usr.foto;
                }
            }
            else
            {                
                ViewBag.resim= "/Yuklemeler/UserFoto/bos.png";
            }
            return View();
        }
        //[HttpPost]
        public JsonResult YorumYap(string yorumum)
        {
            UserG usr = (UserG)Session["userbilgi"];
            if (yorumum==null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            DB.UserYorumlar.Add(new UserYorum { userId = usr.ID, userAdi = usr.adi, tarih = DateTime.Now, yorum = yorumum,foto=usr.foto });
            DB.SaveChanges();
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}