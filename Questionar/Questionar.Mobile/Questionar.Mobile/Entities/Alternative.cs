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
    public class Alternative 
    {
        public virtual int Id { get; set; }

        public virtual Question Question { get; set; }

        public virtual string Description { get; set; }

        public virtual Int32 Order { get; set; }

        public virtual bool IsCorrect { get; set; }
    }
}