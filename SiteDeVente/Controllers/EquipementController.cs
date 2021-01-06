using SiteDeVente.Factories;
using SiteDeVente.Models;
using SiteDeVente.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteDeVente.Controllers
{
    public class EquipementController : Controller
    {
        // GET: Equipement
        public ActionResult Index(Guid secteurId, String secteurName)
        {
            Secteur secteur = new Secteur(secteurId, secteurName);

            ShoppingCart shoppingCartSession = (ShoppingCart)HttpContext.Session["ShoppingCart"];
            return View(secteur);
        }

        [HttpPost]
        public ActionResult DeleteEquipement(Guid equipementId, Guid secteurId)
        {
            BdGestion bdGestion = new BdGestion();
            bdGestion.Connection();

            EquipementFactory equipementFactory = new EquipementFactory(bdGestion.Cnn);
            equipementFactory.DeleteById(equipementId);
            List<Equipement> equipements = equipementFactory.GetAllFromSecteurId(secteurId);
            SecteurFactory secteurFactory = new SecteurFactory(bdGestion.Cnn);
            Secteur secteur = secteurFactory.GetById(secteurId);

            bdGestion.CloseConnection();
            SecteurEquipement secteurEquipement = new SecteurEquipement(equipements, secteur);

            return PartialView("_EquipementList", secteurEquipement);
        }

        public ActionResult AddEquipement(Guid secteurId, String SecteurName, String equipementName, String equipementPriceString, String equipementDescription, String equipementImageName)
        {
            BdGestion bdGestion = new BdGestion();
            bdGestion.Connection();
            SecteurFactory secteurFactory = new SecteurFactory(bdGestion.Cnn);
            Secteur secteur = secteurFactory.GetById(secteurId);

            if (!nameValidation(equipementName) || !priceValidation(ref equipementPriceString) || !descriptionValidation(equipementDescription) || !imageValidation(equipementImageName))
            {
                bdGestion.CloseConnection();
                return View(secteur);
            }
            
            Equipement equipement = new Equipement(equipementName, Convert.ToDouble(equipementPriceString), equipementDescription, equipementImageName, secteur.Id);          
            EquipementFactory equipementFactory = new EquipementFactory(bdGestion.Cnn);
            equipementFactory.AddEquipement(equipement);
            List<Equipement> equipements = equipementFactory.GetAllFromSecteurId(secteur.Id);
            bdGestion.CloseConnection();
            SecteurEquipement secteurEquipement = new SecteurEquipement(equipements, secteur);

            return PartialView("_EquipementList", secteurEquipement);
        }

        public ActionResult UpdateEquipement(Guid secteurId, Guid equipementId, String equipementName, String equipementPrice, String equipementDescription, String equipementImageName)
        {
            BdGestion bdGestion = new BdGestion();
            bdGestion.Connection();
            SecteurFactory secteurFactory = new SecteurFactory(bdGestion.Cnn);
            Secteur secteur = secteurFactory.GetById(secteurId);

            if (!nameValidation(equipementName) || !priceValidation(ref equipementPrice) || !descriptionValidation(equipementDescription) || !imageValidation(equipementImageName))
            {
                bdGestion.CloseConnection();
                return View(secteur);
            }
    
            EquipementFactory equipementFactory = new EquipementFactory(bdGestion.Cnn);            
            equipementFactory.UpdateEquipement(equipementId, equipementName, Convert.ToDouble(equipementPrice), equipementDescription, equipementImageName);
            List<Equipement> equipements = equipementFactory.GetAllFromSecteurId(secteurId);      
            bdGestion.CloseConnection();
            SecteurEquipement secteurEquipement = new SecteurEquipement(equipements, secteur);

            return PartialView("_EquipementList", secteurEquipement);
        }

        public ActionResult EquipementList(Secteur secteur)
        {
            BdGestion bdGestion = new BdGestion();
            bdGestion.Connection();

            EquipementFactory equipementFactory = new EquipementFactory(bdGestion.Cnn);
            List<Equipement> equipements = equipementFactory.GetAllFromSecteurId(secteur.Id);
            SecteurEquipement secteurEquipement = new SecteurEquipement(equipements, secteur);

            return PartialView("_EquipementList", secteurEquipement);
        }


        public ActionResult AddToCart(Guid equipementId)
        {
            Equipement equipement = GetEquipementById(equipementId);
            Secteur secteur = GetSecteurById(equipement.SecteurId);
            ShoppingCart shoppingCartSession = CheckShoppingCartSession();
            Boolean itemInCart = false;
            foreach (Item item in shoppingCartSession.Items)
            {
                if (item.Equipement.Id == equipement.Id)
                {
                    item.Quantity++;
                    itemInCart = true;
                }
            }

            if (!itemInCart)
            {
                Item item = new Item(equipement, secteur, shoppingCartSession.Id);
                shoppingCartSession.Items.Add(item);
            }

            String message = equipement.Name + " à bien été ajouté au panier !";
            return Json(new { message }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteToCart(Guid equipementId)
        {
            Equipement equipement = GetEquipementById(equipementId);
            ShoppingCart shoppingCartSession = CheckShoppingCartSession();

            String message;
            if (shoppingCartSession.Items.RemoveAll(obj => obj.Equipement.Id == equipement.Id) == 0)
            {
                message = equipement.Name + " n'est pas dans le panier !";
                return Json(new { message }, JsonRequestBehavior.AllowGet);
            }

            message = equipement.Name + " à bien été enlevé du panier !";
            return Json(new { message }, JsonRequestBehavior.AllowGet);
        }

        public Equipement GetEquipementById(Guid equipementId)
        {
            BdGestion bdGestion = new BdGestion();
            bdGestion.Connection();

            EquipementFactory equipementFactory = new EquipementFactory(bdGestion.Cnn);

            Equipement equipement = equipementFactory.GetById(equipementId);

            bdGestion.CloseConnection();

            return equipement;
        }

        public Secteur GetSecteurById(Guid secteurId)
        {
            BdGestion bdGestion = new BdGestion();
            bdGestion.Connection();

            SecteurFactory secteurFactory = new SecteurFactory(bdGestion.Cnn);
            Secteur secteur = secteurFactory.GetById(secteurId);
            bdGestion.CloseConnection();

            return secteur;
        }

        public ShoppingCart CheckShoppingCartSession()
        {
            ShoppingCart shoppingCartSession = (ShoppingCart)HttpContext.Session["ShoppingCart"];

            if (shoppingCartSession == null)
            {
                ShoppingCart shoppingCart = new ShoppingCart();
                shoppingCart.Items = new List<Item>();
                shoppingCart.Id = Guid.NewGuid();
                shoppingCartSession = shoppingCart;
                HttpContext.Session["ShoppingCart"] = shoppingCartSession;
            }

            return shoppingCartSession;
        }

        private Boolean nameValidation(String equipementName)
        {
            if (equipementName.Length > 50 || equipementName.Length < 0)
            {
                return false;
            }
            return true;
        }

        private Boolean priceValidation(ref String price)
        {
            price = price.Replace('.', ',');
            Double number;
            if (Double.TryParse(price, out number) == false)
            {
                return false;
            }
            if (number > 9999.99)
            {
                return false;
            }
            return true;
        }

        private Boolean descriptionValidation(String description)
        {
            if (description.Length > 100)
            {
                return false;
            }
            return true;
        }

        private Boolean imageValidation(String image)
        {
            if (image.Length > 100)
            {
                return false;
            }
            return true;
        }
    }
}