

namespace Library
{
    public class RouteConfig
    {
        public static void ConfigureRoutes(IRouteBuilder routes)
        {
            routes.MapRoute(
                name: "Library",
                template: "Library",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "LibraryBooks",
                template: "Library/Books",
                defaults: new { controller = "Books", action = "Index" }
            );

            routes.MapRoute(
                name: "LibraryProfile",
                template: "Library/Profile/{id?}",
                defaults: new { controller = "Profile", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                template: "{controller=Home}/{action=Index}/{id?}"
            );
        }
    }
}
