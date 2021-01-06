using SiteDeVente.Factories;
using SiteDeVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteDeVente.Controllers
{
    public class UserConnectionController : Controller
    {
        public JsonResult RegisterUser(String userName, String userPassword)
        {
            Boolean valid = true;
            if (!UserNameValidation(userName) || !UserPasswordValidation(userPassword))
            {
                valid = false;
                return Json(new { valid }, JsonRequestBehavior.AllowGet);
            }

            User user = new User(userName, userPassword, false);
            BdGestion bdGestion = new BdGestion();
            bdGestion.Connection();
            UserConnectionFactory userConnectionFactory = new UserConnectionFactory(bdGestion.Cnn);
            userConnectionFactory.InsertUser(user);
            bdGestion.CloseConnection();

            return Json(new { valid, user.Id }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SendUserConnection(String userName, String userPassword)
        {
            Boolean valid = true;
            if (!UserNameValidation(userName) || !UserPasswordValidation(userPassword))
            {
                valid = false;
                return Json(new { valid }, JsonRequestBehavior.AllowGet);
            }

            BdGestion bdGestion = new BdGestion();
            bdGestion.Connection();
            UserConnectionFactory userConnectionFactory = new UserConnectionFactory(bdGestion.Cnn);
            User user = userConnectionFactory.GetByUserNameAndPassword(userName, userPassword);
            bdGestion.CloseConnection();

            if (user == null)
            {
                valid = false;
                return Json(new { valid }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { valid, user.Id }, JsonRequestBehavior.AllowGet);
        }


        public void Deconnection()
        {
            Session.Contents.RemoveAll();
        }


        private Boolean UserNameValidation(String userName)
        {
            if (userName.Length > 50)
                return false;
            else
                return true;
        }

        private Boolean UserPasswordValidation(String password)
        {
            if (password.Length > 50)
                return false;
            else
                return true;
        }
    }
}