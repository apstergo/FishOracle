using Akavache;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fishphone
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ManualAll : ContentPage
	{
        List<Manualcs> manualList = new List<Manualcs>();
        public ManualAll (int i)
		{
			InitializeComponent ();
            RunAsyc(i);
            baner.Source = null;
            baner.Source = new UriImageSource { CachingEnabled = true, Uri = new Uri("http://ribakiriba.ru/advertisingplace.png") };
        }

        private async void ListFish_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Manualcs;
            await Navigation.PushAsync(new ManualOne(content));
            ListFish.SelectedItem = null;
        }
        public async void RunAsyc(int i)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string s;
                    client.BaseAddress = new Uri("http://ribakiriba.ru");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if(i==1)
                    {
                        HttpResponseMessage response = await client.GetAsync("api/fish.php");
                        if (response.IsSuccessStatusCode)
                        {
                            s = await response.Content.ReadAsStringAsync();
                            JArray json = JArray.Parse(s);
                            manualList = JsonConvert.DeserializeObject<List<Manualcs>>(json.ToString());
                            ListFish.ItemsSource = manualList;
                        }
                        else
                        {
                            ListFish.ItemsSource = null;
                            var manualcache = await BlobCache.UserAccount.GetObject<List<Manualcs>>("ManualFishCache");
                            ListFish.ItemsSource = manualcache;
                        }
                    }
                    if (i == 2)
                    {
                        HttpResponseMessage response = await client.GetAsync("api/lodki.php");
                        if (response.IsSuccessStatusCode)
                        {
                            s = await response.Content.ReadAsStringAsync();
                            JArray json = JArray.Parse(s);
                            manualList = JsonConvert.DeserializeObject<List<Manualcs>>(json.ToString());
                            ListFish.ItemsSource = manualList;
                        }
                        else
                        {
                            ListFish.ItemsSource = null;
                            var manualcache = await BlobCache.UserAccount.GetObject<List<Manualcs>>("ManualLodkiCache");
                            ListFish.ItemsSource = manualcache;
                        }
                    }
                    if (i == 3)
                    {
                        HttpResponseMessage response = await client.GetAsync("api/tool.php");
                        if (response.IsSuccessStatusCode)
                        {
                            s = await response.Content.ReadAsStringAsync();
                            JArray json = JArray.Parse(s);
                            manualList = JsonConvert.DeserializeObject<List<Manualcs>>(json.ToString());
                            ListFish.ItemsSource = manualList;
                        }
                        else
                        {
                            ListFish.ItemsSource = null;
                            var manualcache = await BlobCache.UserAccount.GetObject<List<Manualcs>>("ManualToolCache");
                            ListFish.ItemsSource = manualcache;
                        }
                    }
                    if (i == 4)
                    {
                        HttpResponseMessage response = await client.GetAsync("api/engen.php");
                        if (response.IsSuccessStatusCode)
                        {
                            s = await response.Content.ReadAsStringAsync();
                            JArray json = JArray.Parse(s);
                            manualList = JsonConvert.DeserializeObject<List<Manualcs>>(json.ToString());
                            ListFish.ItemsSource = manualList;
                        }
                        else
                        {
                            ListFish.ItemsSource = null;
                            var manualcache = await BlobCache.UserAccount.GetObject<List<Manualcs>>("ManualEngenCache");
                            ListFish.ItemsSource = manualcache;
                        }
                    }

                }
                ChaceAll();
            }
            catch
            {
                if(i == 1)
                {
                    ListFish.ItemsSource = null;
                    var manualcache = await BlobCache.UserAccount.GetObject<List<Manualcs>>("ManualFishCache");
                    manualList = manualcache;
                    ListFish.ItemsSource = manualcache;
                }
                if (i == 2)
                {
                    ListFish.ItemsSource = null;
                    var manualcache = await BlobCache.UserAccount.GetObject<List<Manualcs>>("ManualLodkiCache");
                    manualList = manualcache;
                    ListFish.ItemsSource = manualcache;
                }
                if (i == 3)
                {
                    ListFish.ItemsSource = null;
                    var manualcache = await BlobCache.UserAccount.GetObject<List<Manualcs>>("ManualToolCache");
                    manualList = manualcache;
                    ListFish.ItemsSource = manualcache;
                }
                if (i == 4)
                {
                    ListFish.ItemsSource = null;
                    var manualcache = await BlobCache.UserAccount.GetObject<List<Manualcs>>("ManualEngenCache");
                    manualList = manualcache;
                    ListFish.ItemsSource = manualcache;
                }
            }
        }

        private async void ChaceAll()
        {
            DateTime datecache = CrossSettings.Current.GetValueOrDefault("ChacheDate", DateTime.MaxValue);
            if(datecache>DateTime.Now.AddDays(1))
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://ribakiriba.ru");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync("api/fish.php");
                    if (response.IsSuccessStatusCode)
                    {
                        string fish = await response.Content.ReadAsStringAsync();
                        JArray json = JArray.Parse(fish);
                        manualList = JsonConvert.DeserializeObject<List<Manualcs>>(json.ToString());
                        await BlobCache.UserAccount.InsertObject("ManualFishCache", manualList);
                    }
                    HttpResponseMessage response1 = await client.GetAsync("api/lodki.php");
                    if (response1.IsSuccessStatusCode)
                    {
                        string lodki = await response1.Content.ReadAsStringAsync();
                        JArray json = JArray.Parse(lodki);
                        manualList = JsonConvert.DeserializeObject<List<Manualcs>>(json.ToString());
                        await BlobCache.UserAccount.InsertObject("ManualLodkiCache", manualList);
                    }
                    HttpResponseMessage response2 = await client.GetAsync("api/tool.php");
                    if (response2.IsSuccessStatusCode)
                    {

                        string tool = await response2.Content.ReadAsStringAsync();
                        JArray json = JArray.Parse(tool);
                        manualList = JsonConvert.DeserializeObject<List<Manualcs>>(json.ToString());
                        await BlobCache.UserAccount.InsertObject("ManualToolCache", manualList);
                    }
                    HttpResponseMessage response3 = await client.GetAsync("api/engen.php");
                    if (response3.IsSuccessStatusCode)
                    {

                        string engen = await response3.Content.ReadAsStringAsync();
                        JArray json = JArray.Parse(engen);
                        manualList = JsonConvert.DeserializeObject<List<Manualcs>>(json.ToString());
                        await BlobCache.UserAccount.InsertObject("ManualEngenCache", manualList);
                    }
                }
                CrossSettings.Current.AddOrUpdateValue("ChacheDate", DateTime.Now);
            }
        }

        private async void Baner_Clicked(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch
            {

            }
            
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ListFish.ItemsSource = manualList;
            }

            else
            {
                ListFish.ItemsSource = manualList.Where(x => x.nameitem.ToUpper().StartsWith(e.NewTextValue.ToUpper()));
            }
        }
    }
}