using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Questionar.Mobile.Entities
{
    public class User 
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

        private bool _active;
        public virtual bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        private bool _isTeacher;
        public virtual bool IsTeacher
        {
            get { return _isTeacher; }
            set { _isTeacher = value; }
        }

        public User()
        {
        }
    }
}