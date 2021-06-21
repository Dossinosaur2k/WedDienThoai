using System.Web.Mvc;

namespace Demowed.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Delete_default",
                "Admin/{controller}/{action}/{user}",
                new { Controller = "User",action="Delete", user = UrlParameter.Optional }
            );

            context.MapRoute(
                "User_Index_default",
                "Admin/{controller}",
                new { Controller ="User", id = UrlParameter.Optional }
            );

        }
    }
}