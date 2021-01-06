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
    public class EquipementFactory : BdGestion
    {
        public EquipementFactory(SqlConnection cnn)
        {
            Cnn = cnn;
        }

        /// <summary>
        /// Select All Equipement from Secteur
        /// </summary>
        /// <returns></returns>
        public List<Equipement> GetAllFromSecteurId(Guid secteurId)
        {
            List<Equipement> equipements = new List<Equipement>();

            String commandText = "SELECT Equipement.Id , Equipement.Name, Equipement.Price, Equipement.Description, Equipement.Image, Equipement.SecteurId FROM Equipement " +
                                    "INNER JOIN Secteur ON Equipement.SecteurId = Secteur.Id " +
                                    "WHERE SecteurId =@secteurId AND Equipement.IsDeleted = 0";

            SqlCommand sqlCommand = new SqlCommand(commandText, Cnn);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("secteurId", secteurId);

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);

                equipements = dataTable.DataTableToList<Equipement>();
            }

            return equipements;
        }

        public Equipement GetById(Guid equipementId)
        {
            Equipement equipement = new Equipement();

            String commandText = "SELECT Equipement.Id , Equipement.Name, Equipement.Price, Equipement.Description, Equipement.Image, Equipement.SecteurId FROM Equipement " +
                                    "INNER JOIN Secteur ON Equipement.SecteurId = Secteur.Id " +
                                    "WHERE Equipement.Id =@equipementId AND Equipement.IsDeleted = 0";

            SqlCommand sqlCommand = new SqlCommand(commandText, Cnn);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("equipementId", equipementId);

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);

                equipement = dataTable.DataTableToObject<Equipement>();
            }

            return equipement;
        }

        public void DeleteById(Guid equipementId)
        {
            String commandText = "UPDATE Equipement SET isDeleted = 1 WHERE Equipement.Id =@equipementId";

            SqlCommand sqlCommand = new SqlCommand(commandText, Cnn);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("equipementId", equipementId);

            sqlCommand.ExecuteNonQuery();
        }

        public void AddEquipement(Equipement equipement)
        {
            String commandText = "INSERT INTO Equipement (Id, SecteurId, IsDeleted, CreatedDate, Name, Price, Description, Image)" +
                                    "VALUES (@equipementId, @secteurId, @isDeleted, @createDate, @equipementName, @equipementPrice, @equipementDescription, @equipementImage)";

            SqlCommand sqlCommand = new SqlCommand(commandText, Cnn);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("equipementId", equipement.Id);
            sqlCommand.Parameters.AddWithValue("secteurId", equipement.SecteurId);
            sqlCommand.Parameters.AddWithValue("isDeleted", equipement.IsDeleted);
            sqlCommand.Parameters.AddWithValue("createDate", equipement.CreatedDate);
            sqlCommand.Parameters.AddWithValue("equipementName", equipement.Name);
            sqlCommand.Parameters.AddWithValue("equipementPrice", equipement.Price);
            sqlCommand.Parameters.AddWithValue("equipementDescription", equipement.Description);
            sqlCommand.Parameters.AddWithValue("equipementImage", equipement.Image);
            sqlCommand.ExecuteNonQuery();
        }

        public void UpdateEquipement(Guid equipementId, String equipementName, Double equipementPriceString, String equipementDescription, String equipementImageName)
        {
            String commandText = "UPDATE Equipement SET Name = @equipementName, Price = @equipementPrice, Description = @equipementDescription, Image = @equipementImage " +
                                    "WHERE id = @equipementId AND IsDeleted = 0";

            SqlCommand sqlCommand = new SqlCommand(commandText, Cnn);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("equipementId", equipementId);
            sqlCommand.Parameters.AddWithValue("equipementName", equipementName);
            sqlCommand.Parameters.AddWithValue("equipementPrice", equipementPriceString);
            sqlCommand.Parameters.AddWithValue("equipementDescription", equipementDescription);
            sqlCommand.Parameters.AddWithValue("equipementImage", equipementImageName);
            sqlCommand.ExecuteNonQuery();
        }
    }
}