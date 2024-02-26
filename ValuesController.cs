using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library
{
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return Content("Hello!");
            }
        }
}
