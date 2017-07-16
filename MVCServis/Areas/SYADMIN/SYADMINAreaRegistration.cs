using System.Web.Mvc;

namespace MVCServis.Areas.SYADMIN
{
    public class SYADMINAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SYADMIN";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SYADMIN_default",
                "SYADMIN/{controller}/{action}/{id}",
                new {Controller="Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}