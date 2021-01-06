using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SiteDeVente
{
    public class BdGestion
    {
        private SqlConnection _Cnn;

        public SqlConnection Cnn
        {
            get { return _Cnn; }
            set
            {
                if (value != _Cnn)
                    _Cnn = value;
            }
        }

        public void Connection()
        {
            String connetionString;
            //connetionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=ClubTaekwondoCapital; Integrated Security=true";
            connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Cnn = new SqlConnection(connetionString);
            Cnn.Open();
        }

        public void CloseConnection()
        {
            Cnn.Close();
        }
    }
}