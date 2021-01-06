using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteDeVente.Models
{
    public class ShoppingCart : BaseModel
    {
        private const Double _TPS = 0.05;
        private const Double _TVQ = 0.0975;

        private List<Item> _Items { get; set; }
        public List<Item> Items
        {
            get { return _Items; }
            set
            {
                if (value != _Items)
                    _Items = value;
            }
        }

        private User _User;
        public User User
        {
            get { return _User; }
            set
            {
                if (value != _User)
                    _User = value;
            }
        }

        public ShoppingCart(Item item, User user)
        {
            Items.Add(item);
            User = user;
        }

        public ShoppingCart() { }

        public Double GetTotalCartPriceNoTx()
        {
            Double TotalPrice = 0;
            foreach (Item item in this.Items)
            {
                TotalPrice = TotalPrice + item.GetTotalItemPrice();
            }
            return TotalPrice;
        }

        public Double GetTotalCartPriceWithTx()
        {
            Double TotalPrice = GetTotalCartPriceNoTx();
            return Math.Round(TotalPrice * (1 + _TPS + _TVQ), 2);
        }

        public Double GetTotalTaxe()
        {
            Double TotalPrice = GetTotalCartPriceNoTx();
            return Math.Round(TotalPrice * (_TPS + _TVQ), 2);
        }
    }
}