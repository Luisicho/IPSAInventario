using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace IPSAInventario.Controllers
{
    public class HomeController : Controller
    {
        //[OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam = "*")] Enable caching
        //[OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)] Disable chaching
        public ActionResult Index()
        {
            return View();
        }
    }
}