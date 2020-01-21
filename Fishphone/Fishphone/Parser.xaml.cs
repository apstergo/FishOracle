using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.Threading;
using Akavache;
using System.Reactive.Linq;
using Plugin.Settings;

namespace Fishphone
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Parser : ContentPage
	{
        List<KlevWeek> klevweek = new List<KlevWeek>();
        public Parser()
        {
            InitializeComponent();
            Subscribe();
            baner.Source = null;
            baner.Source = new UriImageSource { CachingEnabled = true, Uri = new Uri("http://ribakiriba.ru/advertisingplace.png") };
            T_Date.Text = "Прогноз на завтра " + DateTime.Now.AddDays(1).ToString("M");
            DAT_Date.Text = "Прогноз на послезавтра " + DateTime.Now.AddDays(2).ToString("M");
            
        }

       

        public async  void RunAsyc(int ind)
        {
            KlevWeek today = new KlevWeek();
            KlevWeek dat = new KlevWeek();
            try
            {
                ActivityParse.IsVisible = true;
                TomorrowKlev.Text = "";
                TomorrowKlevScore.Text = "";
                Gauge_Lable.Text = "";
                Moon_Lable.Text = "";
                Moonhalf_Lable.Text = "";
                Wind_Lable.Text = "";
                DATLable.Text = "";
                DATScore.Text = "";
                WeatherDAT.Source = "";
                Weather.Source = "";

                using (HttpClient client = new HttpClient())
                {
                    string s;
                    client.BaseAddress = new Uri("http://ribakiriba.ru");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //HttpResponseMessage response = await client.GetAsync("api/parser.php");
                    //if (response.IsSuccessStatusCode)
                    //{
                    //    s = await response.Content.ReadAsStringAsync();
                    //    JObject json = JObject.Parse(s);
                    //    var str = json.SelectToken(@"$." + ind.ToString());
                    //    Citycs city = new Citycs();
                    //    var citInfo = JsonConvert.DeserializeObject<Citycs>(str.ToString());
                    //    //TomorrowKlev.Text = citInfo.status;
                    //    //TomorrowKlevScore.Text = citInfo.score;
                    //    //Gauge_Lable.Text = citInfo.preasure;
                    //    //Moon_Lable.Text = citInfo.moonday;
                    //    //Moonhalf_Lable.Text = citInfo.moon;

                    //    //if (citInfo.moon == "убывающая луна")
                    //    //{
                    //    //    Moon_Ico.Source = "iconmoonhalf2.png";
                    //    //}
                    //    //else if (citInfo.moon == "Полнолуние")
                    //    //{
                    //    //    Moon_Ico.Source = "iconfullmoon.png";
                    //    //}
                    //    //else if (citInfo.moon == "1-я четверть")
                    //    //{
                    //    //    Moon_Ico.Source = "iconcrescent.png";
                    //    //}
                    //    //else
                    //    //{
                    //    //    Moon_Ico.Source = "iconfullmoon.png";
                    //    //}


                    //    //if (citInfo.weather == "sun")
                    //    //{
                    //    //    Weather.Source = "sanny.png";
                    //    //}
                    //    //else if (citInfo.weather == "cloud-rain")
                    //    //{
                    //    //    Weather.Source = "iconrain.png";
                    //    //}
                    //    //else if (citInfo.weather == "cloud")
                    //    //{
                    //    //    Weather.Source = "cloudy1.png";
                    //    //}
                    //    //else if (citInfo.weather == "cloud-storm-rain")
                    //    //{
                    //    //    Weather.Source = "iconrain2.png";
                    //    //}
                    //    //else if (citInfo.weather == "sun-cloud")
                    //    //{
                    //    //    Weather.Source = "cloudy.png";
                    //    //}
                    //    //else if (citInfo.weather == "sun-cloud-rain")
                    //    //{
                    //    //    Weather.Source = "iconcloudy1.png";
                    //    //}
                    //    //else if (citInfo.weather == "sun")
                    //    //{
                    //    //    Weather.Source = "";
                    //    //}
                    //    //else
                    //    //{
                    //    //    Weather.Source = "sanny.png";
                    //    //}


                    //    //if (citInfo.weather_dat == "sun")
                    //    //{
                    //    //    WeatherDAT.Source = "sanny.png";
                    //    //}
                    //    //else if (citInfo.weather_dat == "cloud-rain")
                    //    //{
                    //    //    WeatherDAT.Source = "iconrain.png";
                    //    //}
                    //    //else if (citInfo.weather_dat == "cloud")
                    //    //{
                    //    //    WeatherDAT.Source = "cloudy1.png";
                    //    //}
                    //    //else if (citInfo.weather_dat == "cloud-storm-rain")
                    //    //{
                    //    //    WeatherDAT.Source = "iconrain2.png";
                    //    //}
                    //    //else if (citInfo.weather_dat == "sun-cloud")
                    //    //{
                    //    //    WeatherDAT.Source = "cloudy.png";
                    //    //}
                    //    //else if (citInfo.weather_dat == "sun-cloud-rain")
                    //    //{
                    //    //    WeatherDAT.Source = "iconcloudy1.png";
                    //    //}
                    //    //else if (citInfo.weather_dat == "sun")
                    //    //{
                    //    //    WeatherDAT.Source = "";
                    //    //}
                    //    //else
                    //    //{
                    //    //    WeatherDAT.Source = "sanny.png";
                    //    //}

                    //    //Wind_Lable.Text = citInfo.wind;
                    //    //DATLable.Text = citInfo.status_dat;
                    //    //DATScore.Text = citInfo.score_dat;
                    //    //CityLable.Text = citInfo.city;
                    //    //StateLable.Text = citInfo.status+" / "+citInfo.score+" / "+citInfo.weather;
                    //    //Weather.Text=citInfo.preasure + " / "+ citInfo.moonday + " / "+ citInfo.wind + " / " + citInfo.moon;
                    //    //DatLable.Text = citInfo.status_dat + " / " + citInfo.score_dat + " / " + citInfo.weather_dat;
                    //    //DatWeather.Text = citInfo.preasure_dat + " / " + citInfo.moonday_dat + " / " + citInfo.wind_dat + " / " + citInfo.moon_dat;
                    //}



                    var values = new Dictionary<string, string>
                    {
                       { "id", ind.ToString() }
                    };

                    
                    var content = new FormUrlEncodedContent(values);


                    var response = await client.PostAsync("api/klevweekstat.php", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        JArray jsonn = JArray.Parse(result);
                        klevweek = JsonConvert.DeserializeObject<List<KlevWeek>>(jsonn.ToString());


                        dat = klevweek.Find(x => x.day.Contains("2"));
                        today = klevweek.FirstOrDefault();
                        TomorrowKlev.Text = today.status;
                        TomorrowKlevScore.Text = today.score;
                        Gauge_Lable.Text = today.preasure;
                        Moon_Lable.Text = today.moonday;
                        Moonhalf_Lable.Text = today.moon;


                        if (today.moon == "убывающая луна")
                        {
                            Moon_Ico.Source = "iconmoonhalf2.png";
                        }
                        else if (today.moon == "Полнолуние")
                        {
                            Moon_Ico.Source = "iconfullmoon.png";
                        }
                        else if (today.moon == "1-я четверть")
                        {
                            Moon_Ico.Source = "iconcrescent.png";
                        }
                        else
                        {
                            Moon_Ico.Source = "iconfullmoon.png";
                        }


                        if (today.weather == "sun")
                        {
                            Weather.Source = "sanny.png";
                        }
                        else if (today.weather == "cloud-rain")
                        {
                            Weather.Source = "iconrain.png";
                        }
                        else if (today.weather == "cloud")
                        {
                            Weather.Source = "cloudy1.png";
                        }
                        else if (today.weather == "cloud-storm-rain")
                        {
                            Weather.Source = "iconrain2.png";
                        }
                        else if (today.weather == "sun-cloud")
                        {
                            Weather.Source = "cloudy.png";
                        }
                        else if (today.weather == "sun-cloud-rain")
                        {
                            Weather.Source = "iconcloudy1.png";
                        }
                        else
                        {
                            Weather.Source = "sanny.png";
                        }


                        if (dat.weather == "sun")
                        {
                            WeatherDAT.Source = "sanny.png";
                        }
                        else if (dat.weather == "cloud-rain")
                        {
                            WeatherDAT.Source = "iconrain.png";
                        }
                        else if (dat.weather == "cloud")
                        {
                            WeatherDAT.Source = "cloudy1.png";
                        }
                        else if (dat.weather == "cloud-storm-rain")
                        {
                            WeatherDAT.Source = "iconrain2.png";
                        }
                        else if (dat.weather == "sun-cloud")
                        {
                            WeatherDAT.Source = "cloudy.png";
                        }
                        else if (dat.weather == "sun-cloud-rain")
                        {
                            WeatherDAT.Source = "iconcloudy1.png";
                        }
                        else if (dat.weather == "sun")
                        {
                            WeatherDAT.Source = "";
                        }
                        else
                        {
                            WeatherDAT.Source = "sanny.png";
                        }

                        Wind_Lable.Text = dat.wind;
                        DATLable.Text = dat.status;
                        DATScore.Text = dat.score;

                        Weeklist.ItemsSource = klevweek;
                    }

                    var values1 = new Dictionary<string, string>
                    {
                       { "id", (CrossSettings.Current.GetValueOrDefault("DefaultCity", 0)+1).ToString() }
                    };


                    var content1 = new FormUrlEncodedContent(values1);


                    var response1 = await client.PostAsync("api/klevweekstat.php", content1);
                    if (response1.IsSuccessStatusCode)
                    {
                        var result1 = await response1.Content.ReadAsStringAsync();
                        JArray jsonn = JArray.Parse(result1);
                        klevweek = JsonConvert.DeserializeObject<List<KlevWeek>>(jsonn.ToString());
                        await BlobCache.UserAccount.InsertObject("ParserLastCityCache", klevweek);
                    }
                }
                    ActivityParse.IsVisible = false;
            }
            catch
            {
                try
                {
                    var klewcache = await BlobCache.UserAccount.GetObject<List<KlevWeek>>("ParserLastCityCache");
                    MessagingCenter.Send<Parser>(this, "DefultCity");
                    if (klewcache != null)
                    {
                        dat = klewcache.Find(x => x.day.Contains("2"));
                        today = klewcache.FirstOrDefault();
                        TomorrowKlev.Text = today.status;
                        TomorrowKlevScore.Text = today.score;
                        Gauge_Lable.Text = today.preasure;
                        Moon_Lable.Text = today.moonday;
                        Moonhalf_Lable.Text = today.moon;


                        if (today.moon == "убывающая луна")
                        {
                            Moon_Ico.Source = "iconmoonhalf2.png";
                        }
                        else if (today.moon == "Полнолуние")
                        {
                            Moon_Ico.Source = "iconfullmoon.png";
                        }
                        else if (today.moon == "1-я четверть")
                        {
                            Moon_Ico.Source = "iconcrescent.png";
                        }
                        else
                        {
                            Moon_Ico.Source = "iconfullmoon.png";
                        }


                        if (today.weather == "sun")
                        {
                            Weather.Source = "sanny.png";
                        }
                        else if (today.weather == "cloud-rain")
                        {
                            Weather.Source = "iconrain.png";
                        }
                        else if (today.weather == "cloud")
                        {
                            Weather.Source = "cloudy1.png";
                        }
                        else if (today.weather == "cloud-storm-rain")
                        {
                            Weather.Source = "iconrain2.png";
                        }
                        else if (today.weather == "sun-cloud")
                        {
                            Weather.Source = "cloudy.png";
                        }
                        else if (today.weather == "sun-cloud-rain")
                        {
                            Weather.Source = "iconcloudy1.png";
                        }
                        else
                        {
                            Weather.Source = "sanny.png";
                        }


                        if (dat.weather == "sun")
                        {
                            WeatherDAT.Source = "sanny.png";
                        }
                        else if (dat.weather == "cloud-rain")
                        {
                            WeatherDAT.Source = "iconrain.png";
                        }
                        else if (dat.weather == "cloud")
                        {
                            WeatherDAT.Source = "cloudy1.png";
                        }
                        else if (dat.weather == "cloud-storm-rain")
                        {
                            WeatherDAT.Source = "iconrain2.png";
                        }
                        else if (dat.weather == "sun-cloud")
                        {
                            WeatherDAT.Source = "cloudy.png";
                        }
                        else if (dat.weather == "sun-cloud-rain")
                        {
                            WeatherDAT.Source = "iconcloudy1.png";
                        }
                        else if (dat.weather == "sun")
                        {
                            WeatherDAT.Source = "";
                        }
                        else
                        {
                            WeatherDAT.Source = "sanny.png";
                        }

                        Wind_Lable.Text = dat.wind;
                        DATLable.Text = dat.status;
                        DATScore.Text = dat.score;

                        Weeklist.ItemsSource = klevweek;
                        ActivityParse.IsVisible = false;
                    }
                }
                catch
                {
                    MessagingCenter.Send<Parser>(this, "DefultCity");
                }
            }
        }
        private void Subscribe()
        {
            MessagingCenter.Subscribe<TabbPage>(
                this, // кто подписывается на сообщения
                "CitySelect",   // название сообщения
                (sender) => { RunAsyc(TabbPage.pickerSelectId+1); });    // вызываемое действие
            MessagingCenter.Subscribe<TabbPage>(
                this, // кто подписывается на сообщения
                "FirstGeo",   // название сообщения
                (sender) => { RunAsyc(TabbPage.pickerSelectId+1); });    // вызываемое действие
        }
        private void picker_SelectedIndexChanged(object sender,EventArgs e)
        {
            //int ind = 0;
            //ind = picker.SelectedIndex;
            //ind += 1;
            //RunAsyc(ind);
        }

        private void Baner_Clicked(object sender, EventArgs e)
        {
            baner.Source = null;
            baner.Source = new UriImageSource { CachingEnabled = true, Uri = new Uri("http://ribakiriba.ru/advertisingplace.png") };
        }
    }
}