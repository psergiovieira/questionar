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

namespace Questionar.Mobile
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Home);
            var layout = FindViewById<LinearLayout>(Resource.Id.layoutPrincial);

            var radioGroup = new RadioGroup(this);
            radioGroup.Orientation = Orientation.Vertical;
            
            var radio1 = new RadioButton(this);
            radio1.Text = "OUTRAS CORES";

            radioGroup.AddView(radio1);
            layout.AddView(radioGroup);

            //layout.AddView();

        }
    }
}