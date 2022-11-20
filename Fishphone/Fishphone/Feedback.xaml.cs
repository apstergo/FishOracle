using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fishphone
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    class Fedback
    {
        public string username { get; set; }
        public string textotz { get; set; }
    }
    public partial class Feedback : ContentPage
    {
        public Feedback()
        {
            InitializeComponent();
           
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("Uri");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var values = new Dictionary<string, string>
                {
                   { "username", NameUser.Text },
                   { "email", Email.Text },
                   { "fedback", ContentText.Text}
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("api/feedback.php", content);
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Спасибо за отзыв", "Отзыв был оставлен", "ОK");
                    var result = await response.Content.ReadAsStringAsync();
                    ContentText.Text = "";
                    NameUser.Text = "";
                    Email.Text = "";
                }


                //var values1 = new Dictionary<string, string>
                //{
                //   { "id", "0" }
                //};


                //var content1 = new FormUrlEncodedContent(values1);


                //var response1 = await client.PostAsync("api/klevweekstat.php", content1);
                //if (response1.IsSuccessStatusCode)
                //{
                //    var result1 = await response1.Content.ReadAsStringAsync();
                //    await DisplayAlert("Спасибо за отзыв", result1, "ОK");
                //    ContentText.Text = "";
                //    NameUser.Text = "";
                //    Email.Text = "";
                //}

            }
        }

        private void Baner_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}