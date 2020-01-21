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
	public partial class FishList : ContentPage
	{
        List<Manualcs> fishList = new List<Manualcs>();
        public FishList ()
		{
			InitializeComponent ();
            RunAsyc();
		}
        public async void RunAsyc()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string s;
                    client.BaseAddress = new Uri("http://ribakiriba.ru");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/fish.php");
                    if (response.IsSuccessStatusCode)
                    {
                        s = await response.Content.ReadAsStringAsync();
                        JArray json = JArray.Parse(s);
                        fishList = JsonConvert.DeserializeObject<List<Manualcs>>(json.ToString());
                        fishList.ForEach(delegate (Manualcs b) {
                            int end = b.opis.Substring(0, 50).LastIndexOf(' ');
                            b.prev = b.opis.Substring(0, end) + "...";
                        });
                        ListFish.ItemsSource = fishList;
                    }

                }

            }
            catch
            {
                
            }
        }

        private async void ListFish_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Manualcs;
            await Navigation.PushAsync(new ManualOne(content));
            ListFish.SelectedItem = null;
        }
    }
}