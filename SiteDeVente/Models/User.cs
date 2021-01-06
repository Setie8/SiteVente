using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteDeVente.Models
{
    public class User : BaseModel
    {
        private String _UserName;           
        private String _Password;
        private Boolean _Admin;

        public String UserName
        {
            get { return _UserName; }
            set
            {
                if (value != _UserName)
                    _UserName = value;
            }
        }

        public String Password
        {
            get { return _Password; }
            set
            {
                if (value != _Password)
                    _Password = value;
            }
        }


        public Boolean Admin
        {
            get { return _Admin; }
            set
            {
                if (value != _Admin)
                    _Admin = value;
            }
        }



        public User(String userName, String password, Boolean admin)
        {
            UserName = userName;
            Password = password;
            Admin = admin;
        }

        public User(){}
    }
}