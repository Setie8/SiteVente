using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteDeVente.Models
{
    public class BaseModel
    {
        private Guid _Id;
        private Boolean _IsDeleted;
        private DateTime _CreatedDate;

        public Guid Id
        {
            get { return _Id; }
            set
            {
                if (value != _Id)
                    _Id = value;
            }
        }
        public Boolean IsDeleted
        {
            get { return _IsDeleted; }
            set
            {
                if (value != _IsDeleted)
                    _IsDeleted = value;
            }
        }
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set
            {
                if (value != _CreatedDate)
                    _CreatedDate = value;
            }
        }

        public BaseModel()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }
    }
}