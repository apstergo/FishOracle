using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fishphone
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class News : ContentPage
    {
        List<Newscl> newsInfo = new List<Newscl>();
        public News ()
		{
			InitializeComponent ();
            RunAsyc();
            Disconnect.IsVisible = false;
            baner.Source = null;
            baner.Source = new UriImageSource { CachingEnabled = true, Uri = new Uri("http://ribakiriba.ru/advertisingplace.png") };
            listview1.RefreshCommand = new Command(() => {
                try
                {
                    RunAsyc();
                    Disconnect.IsVisible = false;
                }
                catch
                {
                    Disconnect.IsVisible = true;
                }
                listview1.IsRefreshing = false;
            });
        }
        
        public  async void RunAsyc()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string s;
                    client.BaseAddress = new Uri("http://ribakiriba.ru");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/news.php");
                    if (response.IsSuccessStatusCode)
                    {
                        s = await response.Content.ReadAsStringAsync();
                        JArray json = JArray.Parse(s);
                        newsInfo = JsonConvert.DeserializeObject<List<Newscl>>(json.ToString());
                        newsInfo.ForEach(delegate (Newscl b) {
                            int end = b.textnews.Substring(0, 200).LastIndexOf(' ');
                            b.prevtextnews = b.textnews.Substring(0, end)+"...";
                            b.date = DateTime.Parse(b.date).ToString("dd.MM.yyyy");
                        });
                        listview1.ItemsSource = newsInfo;
                    }

                }
                Disconnect.IsVisible = false;
            }
            catch
            {
                Disconnect.IsVisible = true;
                listview1.ItemsSource = null;
            }
        }

        private async void Listview1_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Newscl;
            await Navigation.PushAsync(new NewsOne(content));
            listview1.SelectedItem = null;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {

        }

        private void Baner_Clicked(object sender, EventArgs e)
        {

        }
    }
}