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
    public class Course 
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual User Teacher { get; set; }

        public virtual DateTime Start { get; set; }
    }
}