using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteDeVente.Controllers
{
    public class FormeController : Controller
    {
        // GET: Forme
        public ActionResult Index()
        {
            return View("ConstructionPage");
        }
    }
}