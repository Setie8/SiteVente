using SiteDeVente.Helper;
using SiteDeVente.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SiteDeVente.Factories
{
    public class SecteurFactory : BdGestion
    {
        public SecteurFactory(SqlConnection cnn)
        {
            Cnn = cnn;
        }

        public Secteur GetById(Guid secteurId)
        {
            Secteur secteur = new Secteur();

            String commandText = "SELECT * FROM Secteur " +
                                    "WHERE IsDeleted = 0 AND Id = @secteurId";

            SqlCommand sqlCommand = new SqlCommand(commandText, Cnn);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("secteurId", secteurId);

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);

                secteur = dataTable.DataTableToObject<Secteur>();
            }

            return secteur;
        }

        public List<Secteur> GetAll()
        {
            List<Secteur> secteurs = new List<Secteur>();

            String commandText = "SELECT * FROM Secteur " +
                                    "WHERE IsDeleted = 0";

            SqlCommand sqlCommand = new SqlCommand(commandText, Cnn);
            sqlCommand.Parameters.Clear();

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);

                secteurs = dataTable.DataTableToList<Secteur>();
            }

            return secteurs;
        }

    }
}