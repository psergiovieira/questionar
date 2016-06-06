
using System;

namespace Data
{
    public class Course : Infraestructure.Types.IIdentity
    {
        private int _id;
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _name;

        private string _description;
        public virtual string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private DateTime _created;
        public virtual DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }
    }
}
