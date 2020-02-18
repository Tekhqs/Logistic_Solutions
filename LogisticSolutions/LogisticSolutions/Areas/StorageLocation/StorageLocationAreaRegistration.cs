using System.Web.Mvc;

namespace LogisticSolutions.Areas.StorageLocation
{
    public class StorageLocationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "StorageLocation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "StorageLocation_default",
                "StorageLocation/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}