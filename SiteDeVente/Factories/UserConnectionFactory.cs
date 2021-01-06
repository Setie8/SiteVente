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
    public class UserConnectionFactory : BdGestion
    {
        public UserConnectionFactory(SqlConnection cnn)
        {
            Cnn = cnn;
        }


        public User GetByUserNameAndPassword(String userName, String userPassword)
        {
            User user = new User();

            String commandText = "SELECT * FROM [User] WHERE UserName =@userName AND Password =@userPassword AND IsDeleted = 0";

            SqlCommand sqlCommand = new SqlCommand(commandText, Cnn);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("userName", userName);
            sqlCommand.Parameters.AddWithValue("userPassword", userPassword);

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);
                user = dataTable.DataTableToObject<User>();
            }
            return user;
        }


        public void InsertUser(User user)
        {
            String commandText = "INSERT INTO [User] (Id, Admin, UserName, Password) VALUES (@userId , @userAdmin , @userName , @userPassword)";

            SqlCommand sqlCommand = new SqlCommand(commandText, Cnn);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("userId", user.Id);
            sqlCommand.Parameters.AddWithValue("userAdmin", user.Admin);
            sqlCommand.Parameters.AddWithValue("userName", user.UserName);
            sqlCommand.Parameters.AddWithValue("userPassword", user.Password);

            sqlCommand.ExecuteNonQuery();
        }


        public User GetUserById(Guid userId)
        {
            User user = new User();

            String commandText = "SELECT * FROM [User] WHERE Id=@userId AND IsDeleted = 0";

            SqlCommand sqlCommand = new SqlCommand(commandText, Cnn);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("userId", userId);

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);
                user = dataTable.DataTableToObject<User>();
            }
            return user;
        }


    }
}