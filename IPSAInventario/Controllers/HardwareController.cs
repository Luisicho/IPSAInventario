using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPSAInventario.ViewModels;
using IPSAInventario.Models;

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
            var newHardware = new HardwareFormViewModel(new Hardware())
            {
            };
            return View("HardwareForm", newHardware);
        }
    }
}