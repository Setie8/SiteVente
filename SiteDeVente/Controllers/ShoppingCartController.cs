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
    public class ShoppingCartController : Controller
    {
        public ActionResult Index()
        {
            ShoppingCart shoppingCartSession = CheckShoppingCartSession();
            return View(shoppingCartSession);
        }


        public ActionResult CartList()
        {
            ShoppingCart shoppingCartSession = CheckShoppingCartSession();
            return PartialView("_CartList", shoppingCartSession);
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

        public JsonResult CheckUserSession(Guid userId)
        {
            ShoppingCart shoppingCartSession = CheckShoppingCartSession();
            BdGestion bdGestion = new BdGestion();
            bdGestion.Connection();

            UserConnectionFactory userConnectionFactory = new UserConnectionFactory(bdGestion.Cnn);
            shoppingCartSession.User = userConnectionFactory.GetUserById(userId);
            bdGestion.CloseConnection();

            return Json(true, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult DeleteToCart(Guid equipementId)
        {
            ShoppingCart shoppingCartSession = CheckShoppingCartSession();
            shoppingCartSession.Items.RemoveAll(obj => obj.Equipement.Id == equipementId);
            return CartList();
        }


        [HttpPost]
        public ActionResult AddToCart(Guid equipementId)
        {
            ShoppingCart shoppingCart = CheckShoppingCartSession();
            foreach (Item item in shoppingCart.Items)
            {
                if (item.Equipement.Id == equipementId)
                {
                    item.Quantity++;
                }
            }
            return CartList();
        }

        [HttpPost]
        public ActionResult RemoveOneToCart(Guid equipementId)
        {
            ShoppingCart shoppingCart = CheckShoppingCartSession();
            foreach (Item item in shoppingCart.Items)
            {
                if (item.Equipement.Id == equipementId)
                {
                    if (item.Quantity > 0)
                    item.Quantity--;
                }
            }
            return CartList();
        }
    }
}