using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteDeVente.Models
{
    public static class SecteurList
    {
        private static List<Secteur> _Secteurs;
        public static List<Secteur> Secteurs
        {
            get { return _Secteurs; }
            set
            {
                if (value != _Secteurs)
                    _Secteurs = value;
            }
        }

        public static String GetSecteurName(Guid secteurId)
        {
            Secteur secteur = Secteurs.First(x => x.Id == secteurId);
            return secteur.Name;
        }
    }
}