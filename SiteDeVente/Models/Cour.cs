using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteDeVente.Models
{
    public class Cour : BaseModel
    {
        [MaxLength(50)]
        private String _Name;
        private Double _Price;
        private String _Description;


        public String Name
        {
            get { return _Name; }
            set
            {
                if (value != _Name)
                    _Name = value;
            }
        }
        public Double Price
        {
            get { return _Price; }
            set
            {
                if (value != _Price)
                    _Price = value;
            }
        }
        public String Description
        {
            get { return _Description; }
            set
            {
                if (value != _Description)
                    _Description = value;
            }
        }

        public Cour(String name, Double price, String description)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public Cour(){

        }
    }
}