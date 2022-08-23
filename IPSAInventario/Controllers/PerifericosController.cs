using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPSAInventario.ViewModels;
using IPSAInventario.Models;

namespace IPSAInventario.Controllers
{
    public class PerifericosController : Controller
    {
        // GET: Perifericos
        public ActionResult Index()
        {
            return View();
        }
        // GET: /Perifericos/NewPerifericos
        public ActionResult NewPerifericos()
        {
            var newPerifericos = new PerifericosFormViewModel(new Perifericos());
            return View("PerifericosForm", newPerifericos);
        }
    }
}