using Akavache;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	public partial class FishList : ContentPage
	{
        List<Fishcs> manualList = new List<Fishcs>();
        List<Fishcs> fishList = new List<Fishcs>();
        private bool alive = true;
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
                    client.BaseAddress = new Uri("Uri");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = await client.GetAsync("api/fish.php");
                        if (response.IsSuccessStatusCode)
                        {
                            s = await response.Content.ReadAsStringAsync();
                            JArray json = JArray.Parse(s);
                            fishList = JsonConvert.DeserializeObject<List<Fishcs>>(json.ToString());
                            var sorted = from item in fishList
                                         orderby item.nameitem
                                         group item by item.NameSort into itemGroup
                                         select new Grouping<string, Fishcs>(itemGroup.Key, itemGroup);
                            var ManuaListGrouped = new ObservableCollection<Grouping<string, Fishcs>>(sorted);
                            ListFish.ItemsSource = ManuaListGrouped;

                            await BlobCache.UserAccount.InsertObject("FishCache", fishList);
                        }
                        else
                        {
                            ListFish.ItemsSource = null;
                            var manualcache = await BlobCache.UserAccount.GetObject<List<Fishcs>>("FishCache");
                            var sorted = from item in manualcache
                                     orderby item.nameitem
                                     group item by item.NameSort into itemGroup
                                     select new Grouping<string, Fishcs>(itemGroup.Key, itemGroup);
                            var ManuaListGrouped = new ObservableCollection<Grouping<string, Fishcs>>(sorted);
                            ListFish.ItemsSource = ManuaListGrouped;
                        }
                    

                }
                ChaceAll();
            }
            catch (Exception ex)
            {
                //DisplayAlert("", ex.ToString(), "ok");
                ListFish.ItemsSource = null;
                var manualcache = await BlobCache.UserAccount.GetObject<List<Fishcs>>("FishCache");
                var sorted = from item in manualcache
                             orderby item.nameitem
                             group item by item.NameSort into itemGroup
                             select new Grouping<string, Fishcs>(itemGroup.Key, itemGroup);
                var ManuaListGrouped = new ObservableCollection<Grouping<string, Fishcs>>(sorted);
                ListFish.ItemsSource = ManuaListGrouped;
            }
        }

        private async void ChaceAll()
        {
            try
            {
                DateTime datecache = CrossSettings.Current.GetValueOrDefault("ChacheDate", DateTime.MaxValue);
                if (datecache > DateTime.Now.AddDays(1))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("Uri");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = await client.GetAsync("api/fish.php");
                        if (response.IsSuccessStatusCode)
                        {
                            string fish = await response.Content.ReadAsStringAsync();
                            JArray json = JArray.Parse(fish);
                            manualList = JsonConvert.DeserializeObject<List<Fishcs>>(json.ToString());
                            
                        }
                    }
                    CrossSettings.Current.AddOrUpdateValue("ChacheDate", DateTime.Now);
                }
            }
            catch
            {

            }
            
        }

        private async void ListFish_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Fishcs;
            await Navigation.PushAsync(new FishOne(content));
            ListFish.SelectedItem = null;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                var sorted = from item in fishList
                             orderby item.nameitem
                             group item by item.NameSort into itemGroup
                             select new Grouping<string, Fishcs>(itemGroup.Key, itemGroup);
                var ManuaListGrouped = new ObservableCollection<Grouping<string, Fishcs>>(sorted);

                ListFish.ItemsSource = ManuaListGrouped;
            }

            else
            {
                var fishsearch= fishList.Where(x => x.nameitem.ToUpper().StartsWith(e.NewTextValue.ToUpper()));
                var sorted = from item in fishsearch
                             orderby item.nameitem
                             group item by item.NameSort into itemGroup
                             select new Grouping<string, Fishcs>(itemGroup.Key, itemGroup);
                var ManuaListGrouped = new ObservableCollection<Grouping<string, Fishcs>>(sorted);

                ListFish.ItemsSource = ManuaListGrouped;
            }
        }

        private void baner_Clicked(object sender, EventArgs e)
        {

        }
    }
}