using SiteDeVente.Factories;
using SiteDeVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteDeVente.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetSecteurList()
        {
            BdGestion bdGestion = new BdGestion();
            bdGestion.Connection();

            SecteurFactory secteurFactory = new SecteurFactory(bdGestion.Cnn);
            List<Secteur> secteurs = secteurFactory.GetAll();

            return PartialView("_SecteurList", secteurs);
        }
    }
}