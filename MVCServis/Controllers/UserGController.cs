using MVCServis.Areas.SYADMIN.DAL;
using MVCServis.Areas.SYADMIN.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCServis.Controllers
{
    public class UserGController : Controller
    {
        SYADMINContext DB = new SYADMINContext();
        // GET: UserG
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserKayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserKayit(UserG user,HttpPostedFileBase Foto)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return View(user);
            }
            try
            {
                UserG email = (from s in DB.Userlar where s.email == user.email select s).FirstOrDefault();
                if (email != null)
                {
                    ModelState.AddModelError("alarm", "Bu mail adresi sisteme kaydolmuş.");
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return View(user);
                }
                user.sifre = FormsAuthentication.HashPasswordForStoringInConfigFile(user.sifre, "SHA1").ToLower();
                user.ipadres = Request.ServerVariables["REMOTE_ADDR"];
                user.uyelikTarih = DateTime.Now;
                user.girisTarih = DateTime.Now;
                user.girissayisi = 0;
                user.yetki = 0;
                user.onay = true;

                if (Foto!=null)
                {
                    WebImage img = new WebImage(Foto.InputStream);
                    FileInfo fotoinfo = new FileInfo(Foto.FileName);
                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(120, 120);
                    img.Save("~/Yuklemeler/UserFoto/" + newfoto);
                    user.foto = "/Yuklemeler/UserFoto/" + newfoto;
                }
                //else
                //{
                //    WebImage img = new WebImage(Foto.InputStream);
                //    FileInfo fotoinfo = new FileInfo(Foto.FileName);
                //    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                //    img.Resize(120, 120);
                //    img.Save("~/Yuklemeler/UserFoto/" + newfoto);
                //    user.foto = "/Yuklemeler/UserFoto/" + newfoto;
                //}

                DB.Userlar.Add(user);
                DB.SaveChanges();
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Content("Üye kaydınız başarıyla oluşturuldu.");
            }
            catch (Exception)
            {
                return View(user);
            }

            
        }
        public ActionResult UserGiris()
        {
           
            ViewBag.Cikis = "Visible";
            ViewBag.Giris = "Hidden";
            return View();
        }
        [HttpPost]
        public ActionResult UserGiris(UserG User)
        {
            if (!ModelState.IsValidField("email") || !ModelState.IsValidField("sifre"))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return View(User);
            }
            try
            {
                string sifre = FormsAuthentication.HashPasswordForStoringInConfigFile(User.sifre, "SHA1").ToLower().ToString();
                UserG user = (from s in DB.Userlar where s.email == User.email && s.sifre == sifre && s.onay == true select s).FirstOrDefault();
                if (user == null)
                {
                    ModelState.AddModelError("alarm", "Email yada şifreniz hatalı. Kontrol ediniz.");
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return View(User);
                }
                else
                {
                    user.ipadres = Request.ServerVariables["REMOTE_ADDR"];
                    user.girisTarih = DateTime.Now;
                    user.girissayisi = user.girissayisi + 1;
                    DB.SaveChanges();
                    Session["userbilgi"] = user;

                    if (User.hatirla == true)
                    {
                        HttpCookie userB = new HttpCookie("bilgi");
                        userB.Values.Add("ukule", user.email.ToString()
                        );
                        userB.Values.Add("ukuls", user.sifre.ToString()
                        );
                        userB.Expires = DateTime.Now.AddDays(100);
                        Response.Cookies.Add(userB);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("UserGiris", "UserG");
            }            
        }
        public ActionResult UserCikis()
        {
            Session["userbilgi"] = null;
            HttpCookie userB = new HttpCookie("bilgi");
            userB.Values.Add("ukule", "");
            userB.Values.Add("ukuls", "");
            userB.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(userB);
            return RedirectToAction("Index", "Home");
        }
    }
}