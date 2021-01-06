using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteDeVente.Models
{
    public class Equipement : BaseModel
    {
        private String _Name;
        private Double _Price;
        private String _Description;
        private String _Image;
        private Guid _SecteurId;

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

        public String Image
        {
            get { return _Image; }
            set
            {
                if (value != _Image)
                    _Image = value;
            }
        }

        public Guid SecteurId
        {
            get { return _SecteurId; }
            set
            {
                if (value != _SecteurId)
                    _SecteurId = value;
            }
        }

        public Equipement(String name, Double price, String description, String image, Guid secteurId)
        {        
            Name = name;
            Price = price;
            Description = description;
            Image = image;
            SecteurId = secteurId;
        }

        public Equipement()
        {
           
        }
    }
}