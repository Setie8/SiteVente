using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteDeVente.Models
{
    public class Secteur : BaseModel
    {
        private String _Name { get; set; }

        public String Name
        {
            get { return _Name; }
            set
            {
                if (value != _Name)
                    _Name = value;
            }
        }

        public Secteur(Guid id, String name)
        {
            Id = id;
            Name = name;
        }        

        public Secteur()
        { }

    }
}