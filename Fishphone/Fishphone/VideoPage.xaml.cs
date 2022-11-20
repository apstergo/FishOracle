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
    public partial class VideoPage : ContentPage
    {
        public List<Video> Links { get; set; }
        public VideoPage()
        {
            InitializeComponent();
            Download();


        }
        private async void Download()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var current = Connectivity.NetworkAccess;
                    if (current == NetworkAccess.Internet)
                    {
                        string s;
                        client.BaseAddress = new Uri("Uri");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = await client.GetAsync("api/video.php");
                        if (response.IsSuccessStatusCode)
                        {
                            s = await response.Content.ReadAsStringAsync();
                            JArray json = JArray.Parse(s);
                            Links = JsonConvert.DeserializeObject<List<Video>>(json.ToString());
                            VideoList.ItemsSource = Links;
                        }
                        else
                        {
                            
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}