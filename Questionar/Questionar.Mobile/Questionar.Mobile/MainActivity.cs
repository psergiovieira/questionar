using System;
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
using Encoding = System.Text.Encoding;
using Stream = System.IO.Stream;

namespace Questionar.Mobile
{
    [Activity(Label = "Questionar", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private string URL = @"http://192.168.2.27/api/";
        protected override void OnCreate(Bundle bundle)
        {
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

                var client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                var uri = new Uri(URL + "User/Login");
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Android.Widget.Toast.MakeText(this, "Login com sucesso!", Android.Widget.ToastLength.Short).Show();
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

        // Gets weather data from the passed URL.
        private async Task<JsonValue> RestAsync(string url)
        {
            try
            {
                // Create an HTTP web request using the URL:
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
                request.ContentType = "application/json";
                request.Method = "GET";

                // Send the request to the server and wait for the response:
                using (WebResponse response = await request.GetResponseAsync())
                {
                    // Get a stream representation of the HTTP web response:
                    using (Stream stream = response.GetResponseStream())
                    {
                        // Use this stream to build a JSON document object:
                        JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                        Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

                        // Return the JSON document:
                        return jsonDoc;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

