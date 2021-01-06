using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteDeVente.Models
{
    public class Item : Equipement
    {
        private Guid _CartId { get; set; }
        private Int32 _Quantity { get; set; }
        private Equipement _Equipement { get; set; }
        private Secteur _Secteur { get; set; }

        public Guid CartId
        {
            get { return _CartId; }
            set
            {
                if (value != _CartId)
                    _CartId = value;
            }
        }

        public Int32 Quantity
        {
            get { return _Quantity; }
            set
            {
                if (value != _Quantity)
                    _Quantity = value;
            }
        }

        public Equipement Equipement
        {
            get { return _Equipement; }
            set
            {
                if (value != _Equipement)
                    _Equipement = value;
            }
        }

        public Secteur Secteur
        {
            get { return _Secteur; }
            set
            {
                if (value != _Secteur)
                    _Secteur = value;
            }
        }

        public Item(Equipement equipement, Secteur secteur, Guid cartId )
        {
            Equipement = equipement;
            Secteur = secteur;
            Quantity = 1;
            CartId = cartId;
        }


        public Double GetTotalItemPrice()
        {
            return Math.Round(this.Quantity * this.Equipement.Price, 2);
        }

    }
}