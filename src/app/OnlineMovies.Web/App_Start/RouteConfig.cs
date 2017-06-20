using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineMovies.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Movies",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Movie", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "MovieReviews",
                url: "{controller}/{id}",
                defaults: new { controller = "MovieReviews", action = "Index", id = "" }
            );
        }
    }
}
