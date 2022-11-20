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
	public partial class KlevPage : ContentPage
	{
		public KlevPage ()
		{
			InitializeComponent ();
		}
        public static async void RunAsyc(int ind, Label StatLable, Label CityLable, Label DatLable)
        {
            using (HttpClient client = new HttpClient())
            {
                string s;
                client.BaseAddress = new Uri("");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/parser.php");
                if (response.IsSuccessStatusCode)
                {
                    s = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(s);
                    var str = json.SelectToken(@"$." + ind.ToString());
                    Citycs city = new Citycs();
                    var citInfo = JsonConvert.DeserializeObject<Citycs>(str.ToString());
                    CityLable.Text = citInfo.city;
                    StatLable.Text = citInfo.status;

                }

            }
        }
        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = 0;
            ind = picker.SelectedIndex;
            ind += 1;
            RunAsyc(ind, StateLable, CityLable, DatLable);
        }
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}