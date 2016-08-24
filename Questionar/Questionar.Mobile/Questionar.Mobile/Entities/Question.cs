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
    public class Question
    {
        public virtual int Id { get; set; }

        public virtual Course Course { get; set; }

        public virtual string Description { get; set; }

        public virtual bool Sent { get; set; }

        public virtual DateTime SentDate { get; set; }

        public virtual int Order { get; set; }
    }
}