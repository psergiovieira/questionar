
using Data.Security;
using System;

namespace Data
{
    public class Subscription : Infraestructure.Types.IIdentity
    {
        private int _id;
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual Course Course
        {
            get { return _course; }
            set { _course = value; }
        }
        private Course _course;

        private User _student;
        public virtual User Student
        {
            get { return _student; }
            set { _student = value; }
        }

        private DateTime _entered;
        public virtual DateTime Entered
        {
            get { return _entered; }
            set { _entered = value; }
        }
    }
}
