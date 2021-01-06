using SiteDeVente.Helper;
using SiteDeVente.Models;
using SiteDeVente.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SiteDeVente.Factories
{
    public class CourFactory : BdGestion
    {
        public CourFactory(SqlConnection cnn)
        {
            Cnn = cnn;
        }

        public List<Cour> GetAll()
        {
            List<Cour> cours = new List<Cour>();

            String commandText = "SELECT * FROM Cours" +
                                    "WHERE IsDeleted = 0";

            SqlCommand sqlCommand = new SqlCommand(commandText, Cnn);
            sqlCommand.Parameters.Clear();

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);

                cours = dataTable.DataTableToList<Cour>();
            }

            return cours;
        }

    }
}