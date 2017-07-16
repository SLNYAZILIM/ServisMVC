using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;

namespace MVCServis.Areas.SYADMIN.Unit
{
    public class baseController:Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controllerName = filterContext.RouteData.Values["controller"].ToString();
            string actionName = filterContext.RouteData.Values["action"].ToString();
            bool kt = controllerName == "Yetkis" && actionName == "Create";

            if (kt)
            {
                if (Session["Yetki"] == null || Session["Yetki"].ToString() != "1")
                {
                    filterContext.Result = new RedirectResult("~/SYADMIN/Home/Giris");
                }
                base.OnActionExecuting(filterContext); 
            }
        }
    }
}