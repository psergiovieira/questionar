using System;
using System.Collections.Generic;
using System.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json;
using Questionar.Mobile.Entities;
using Questionar.Mobile.Utils;
using Encoding = System.Text.Encoding;
using Stream = System.IO.Stream;

namespace Questionar.Mobile
{
    [Activity(Label = "Questionar", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private HttpClient Client;
        private string URL = Constants.URL;
        protected override void OnCreate(Bundle bundle)
        {
            Client = HttpHelper.Client;

            base.OnCreate(bundle);
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var login = FindViewById<Button>(Resource.Id.logIn);

            ////Login button click action
            login.Click += async (object sender, EventArgs e) =>
            {
               await LoginAsync();
            };
        }

        public async Task LoginAsync()
        {
            try
            {
                var userName = FindViewById<EditText>(Resource.Id.userName).Text;
                var password = FindViewById<EditText>(Resource.Id.password).Text;
                var user = new User() { UserName = userName, Password = password };

                
                Client.MaxResponseContentBufferSize = 256000;
                var uri = new Uri(URL + "User/Login");
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;

                response = await Client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Android.Widget.Toast.MakeText(this, "Login com sucesso!", Android.Widget.ToastLength.Short).Show();
                    StartActivity(typeof(HomeActivity));
                    
                }
                else
                {
                    Android.Widget.Toast.MakeText(this, "Falha ao logar, por favor, tente mais tarde.", Android.Widget.ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

