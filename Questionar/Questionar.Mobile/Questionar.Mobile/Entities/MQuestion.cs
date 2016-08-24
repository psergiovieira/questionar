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
    public class MQuestion
    {
        public int Id { get; set; }
        public Course Course { get; set; }

        public string Description { get; set; }

        public List<Alternative> Alternatives { get; set; }

        public DateTime SentDate { get; set; }

        public bool Sent { get; set; }
    }
}