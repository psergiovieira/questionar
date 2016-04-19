using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Security
{
    public class User : Infraestructure.Types.IIdentity
    {
        private int _id;

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _password;

        public virtual string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _email;

        public virtual string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private DateTime _created;

        public virtual DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        private string _userName;
        public virtual string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public User()
        {
        }
    }
}
