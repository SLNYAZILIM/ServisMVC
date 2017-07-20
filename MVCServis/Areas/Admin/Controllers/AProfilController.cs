using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCServis.Areas.Admin.Controllers
{
    public class AProfilController : Controller
    {
        SYADMIN.DAL.SYADMINContext DB = new SYADMIN.DAL.SYADMINContext();
        // GET: Admin/AProfil
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProfilimEdit()
        {
            return View();
        }
        public ActionResult ProfilimDetay()
        {
            return View();
        }
    }
}