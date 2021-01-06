using SiteDeVente.Factories;
using SiteDeVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteDeVente.Controllers
{
    public class CourController : Controller
    {
        // GET: Cour
        public ActionResult Index()
        {
            //BdGestion bdGestion = new BdGestion();
            //bdGestion.Connection();

            //CourFactory courFactory = new CourFactory(bdGestion.Cnn);

            //List<Cour> cour = courFactory.GetAll();

            //bdGestion.CloseConnection();

            //return View(cour);
            return View("ConstructionPage");
        }
    }
}