using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteDeVente.Models.DataModel
{
    public class SecteurEquipement
    {
        private List<Equipement> _Equipements;
        private Secteur _Secteur;

        public List<Equipement> Equipements
        {
            get { return _Equipements; }
            set
            {
                if (value != _Equipements)
                    _Equipements = value;
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

        public SecteurEquipement(List<Equipement> equipements, Secteur secteur)
        {
            Equipements = equipements;
            Secteur = secteur;
        }
    }
}