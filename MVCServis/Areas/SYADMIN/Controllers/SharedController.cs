using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCServis.Areas.SYADMIN.Controllers
{
    public class SharedController : Controller
    {
        // GET: SYADMIN/Shared
        public ActionResult _LayoutSYadmin()
        {
            return View();
        }
    }
}