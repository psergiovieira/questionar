using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Views;
using Android.Widget;
using Java.Net;
using Newtonsoft.Json;
using Questionar.Mobile.Entities;
using Questionar.Mobile.Utils;

namespace Questionar.Mobile
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity
    {
        private int _idAlternative = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Home);
            LoadQuestion();
       
            //

            //var radioGroup = new RadioGroup(this);
            //radioGroup.Orientation = Orientation.Vertical;

            //var radio1 = new RadioButton(this);
            //radio1.Text = "OUTRAS CORES";

            //radioGroup.AddView(radio1);
            //layout.AddView(radioGroup);

            ////layout.AddView();

        }

        public async void LoadQuestion()
        {
            try
            {
                var uri = new Uri(Constants.URL + "UserQuestion/Get");
                var response = await HttpHelper.Client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    MQuestion question = JsonConvert.DeserializeObject<MQuestion>(content);
                    if (question != null)
                    {
                        var layout = FindViewById<LinearLayout>(Resource.Id.mainLayout);
                        var textQuestion = new TextView(this);
                        textQuestion.Text = question.Description;
                        textQuestion.TextSize = 17;
                        layout.AddView(textQuestion);


                        var radioGroup = new RadioGroup(this);
                        radioGroup.Orientation = Orientation.Vertical;
                        foreach (var alternative in question.Alternatives)
                        {
                            var radio = new RadioButton(this);
                            radio.Text = alternative.Description;
                            radio.Id = alternative.Id;
                            radio.Click += RadioButtonClick;
                            radioGroup.AddView(radio);
                        }

                        layout.AddView(radioGroup);

                        var buttonConfirm = new Button(this);
                        buttonConfirm.Text = "Responder";
                        buttonConfirm.SetWidth(70);
                        buttonConfirm.SetHeight(40);
                        buttonConfirm.Click += ButtonConfirmOnClick;

                        layout.AddView(buttonConfirm);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private async void ButtonConfirmOnClick(object sender, EventArgs eventArgs)
        {
            if (_idAlternative == 0)
            {
                Android.Widget.Toast.MakeText(this, "Selecione uma das alternativas.", ToastLength.Short).Show();
            }
            else
            {
                var alternative = new Alternative(){Id = _idAlternative};
                var uri = new Uri(Constants.URL + "Answer/Post");
                var json = JsonConvert.SerializeObject(alternative);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;

                response = await HttpHelper.Client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    var feedback = await response.Content.ReadAsStringAsync();
                    Toast.MakeText(this, feedback, ToastLength.Short).Show();
                    StartActivity(typeof(HomeActivity));

                }
            }
        }

        private void RadioButtonClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            _idAlternative = rb.Id;
        }
    }
}