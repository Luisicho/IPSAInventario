using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPSAInventario.Controllers
{
    public class HardwareController : Controller
    {
        // GET: /Hardware
        public ActionResult Index()
        {
            return View();
        }
        // GET: /Hardware/NewHardware
        public ActionResult NewHardware()
        {
            return View("HardwareForm");
        }
    }
}