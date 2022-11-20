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
            //baner.Source = null;
            T_Date.Text = "Прогноз на завтра " + DateTime.Now.AddDays(1).ToString("M");
            if(BanerBG.Color==Color.Transparent)
            {
                BanerGrid.IsVisible = false;
            }
            //DAT_Date.Text = "Прогноз на послезавтра " + DateTime.Now.AddDays(2).ToString("M");
            if(Device.RuntimePlatform==Device.Android)
            {
                Advert();
            }
        }


        private async void Advert()
        {
            DependencyService.Get<IAdInterstitial>().LoadAd();
            await Task.Delay(10000);
            DependencyService.Get<IAdInterstitial>().LoadAd();
            await Task.Delay(1500);
            DependencyService.Get<IAdInterstitial>().ShowAd();
        }

        bool PanelVisible = false;
        double y;

        public async  void RunAsyc(int ind)
        {
            KlevWeek today = new KlevWeek();
            KlevWeek dat = new KlevWeek();
            try
            {
                ActivityParse.IsVisible = true;
                TomorrowKlev.Text = "";
                TomorrowKlevScore.Text = "";
                TomorrowKlevProc.Text = "";
                Gauge_Lable.Text = "";
                Temp_Lable.Text = "";
                Moonhalf_Lable.Text = "";
                Wind_Lable.Text = "";
                TodayStatus.Text = "";
                TodayScore.Text = "";
                TodayWeather.Source = "";
                Weather.Source = "";

                using (HttpClient client = new HttpClient())
                {
                    string s;
                    client.BaseAddress = new Uri("Uri");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



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
                        TomorrowKlevProc.Text = "%";
                        Gauge_Lable.Text = today.preasure;
                        Temp_Lable.Text = today.temp;
                        Moonhalf_Lable.Text = today.moon;

                        if (Convert.ToInt32(today.score) > 70)
                        {
                            BGImage.Source = "GoodFishBite.png";
                        }
                        else
                        {
                            BGImage.Source = "BadFishBite.png";
                        }

                        TodayStatus.Text= today.status;
                        TodayScore.Text = today.score;
                        TodayWeather.Source = "dark"+today.weather;
                        TodayTemp.Text = today.temp;
                        TodayWeekDay.Text = DateTime.Now.ToString("ddd");
                        TodayDate.Text = DateTime.Now.ToString("dd.MM");

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

                        Weather.Source = today.weather;
                        Wind_Lable.Text = dat.wind;
                        DATLable.Text = dat.status;
                        DATScore.Text = dat.score;


                        List<KlevWeek> klevweek1 = new List<KlevWeek>();
                        klevweek1 = klevweek;
                        DateTime dt = DateTime.Now;

                        var itemToDelete = klevweek1.Where(x => x.day == "1").Select(x => x).First();
                        klevweek1.RemoveRange(0, 1);

                        klevweek1.ForEach(delegate (KlevWeek kl) {
                            dt = dt.AddDays(1);
                            kl.weather = "dark" + kl.weather;
                            kl.date = dt.Date.ToString("dd.MM");
                            kl.dayweek= dt.Date.ToString("ddd");
                        });         

                        
                        Weeklist.ItemsSource = klevweek1;
                        klevweek1 =null;
                    }
                    else
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
                                TomorrowKlevProc.Text = "%";
                                Gauge_Lable.Text = today.preasure;
                                Temp_Lable.Text = today.temp;
                                Moonhalf_Lable.Text = today.moon;

                                if(Convert.ToInt32(today.score)>70)
                                {
                                    BGImage.Source = "GoodFishBite.png";
                                }
                                else
                                {
                                    BGImage.Source = "BadFishBite.png";
                                }

                                TodayStatus.Text = today.status;
                                TodayScore.Text = today.score;
                                TodayWeather.Source = "dark" + today.weather;
                                TodayTemp.Text = today.temp;
                                TodayWeekDay.Text = DateTime.Now.ToString("ddd");
                                TodayDate.Text = DateTime.Now.ToString("dd.MM");

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

                                WeatherDAT.Source = dat.weather;


                                Wind_Lable.Text = dat.wind;
                                DATLable.Text = dat.status;
                                DATScore.Text = dat.score;

                                List<KlevWeek> klevweek1 = new List<KlevWeek>();
                                klevweek1 = klevweek;
                                DateTime dt = DateTime.Now;

                                var itemToDelete = klevweek1.Where(x => x.day == "1").Select(x => x).First();
                                klevweek1.RemoveRange(0, 1);

                                klevweek1.ForEach(delegate (KlevWeek kl) {
                                    dt = dt.AddDays(1);
                                    kl.weather = "dark" + kl.weather;
                                    kl.date = dt.Date.ToString("dd.MM");
                                    kl.dayweek = dt.Date.ToString("ddd");
                                });


                                Weeklist.ItemsSource = klevweek1;
                                ActivityParse.IsVisible = false;
                            }
                        }
                        catch
                        {
                            MessagingCenter.Send<Parser>(this, "DefultCity");
                        }
                    }

                    var values1 = new Dictionary<string, string>
                    {
                       { "id", (CrossSettings.Current.GetValueOrDefault("DefaultCity", 0)+1).ToString() }
                    };


                    var content1 = new FormUrlEncodedContent(values1);


                    var response1 = await client.PostAsync("api/klevweekstat.php", content1);
                    if (response1.IsSuccessStatusCode)
                    {
                        //DisplayAlert("", "cache", "ok");
                        var result1 = await response1.Content.ReadAsStringAsync();
                        JArray jsonn = JArray.Parse(result1);
                        klevweek = JsonConvert.DeserializeObject<List<KlevWeek>>(jsonn.ToString());
                        await BlobCache.UserAccount.InsertObject("ParserLastCityCache", klevweek);
                    }
                }
                    ActivityParse.IsVisible = false;
            }
            catch(Exception ex)
            {
                //DisplayAlert("", ex.ToString(), "ok");
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
                        TomorrowKlevProc.Text = "%";
                        Gauge_Lable.Text = today.preasure;
                        Temp_Lable.Text = today.temp;
                        Moonhalf_Lable.Text = today.moon;


                        TodayStatus.Text = today.status;
                        TodayScore.Text = today.score;
                        TodayWeather.Source = "dark" + today.weather;
                        TodayTemp.Text = today.temp;
                        TodayWeekDay.Text = DateTime.Now.ToString("ddd");
                        TodayDate.Text = DateTime.Now.ToString("dd.MM");

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

                        WeatherDAT.Source = dat.weather;


                        Wind_Lable.Text = dat.wind;
                        DATLable.Text = dat.status;
                        DATScore.Text = dat.score;

                        List<KlevWeek> klevweek1 = new List<KlevWeek>();
                        klevweek1 = klewcache;
                        DateTime dt = DateTime.Now;

                        var itemToDelete = klevweek1.Where(x => x.day == "1").Select(x => x).First();
                        klevweek1.RemoveRange(0, 1);

                        klevweek1.ForEach(delegate (KlevWeek kl) {
                            dt = dt.AddDays(1);
                            kl.weather = "dark" + kl.weather;
                            kl.date = dt.Date.ToString("dd.MM");
                            kl.dayweek = dt.Date.ToString("ddd");
                        });


                        Weeklist.ItemsSource = klevweek1;
                        ActivityParse.IsVisible = false;
                    }
                }
                catch(Exception exx)
                {
                    //DisplayAlert("", exx.ToString(), "ok");
                    MessagingCenter.Send<Parser>(this, "DefultCity");
                }
            }
        }
        private void Subscribe()
        {
            MessagingCenter.Subscribe<TabbPage>(
                this, // кто подписывается на сообщения
                "CitySelect",   // название сообщения
                (sender) => { RunAsyc(TabbPage.pickerSelectId); });    // вызываемое действие
            MessagingCenter.Subscribe<TabbPage>(
                this, // кто подписывается на сообщения
                "FirstGeo",   // название сообщения
                (sender) => { RunAsyc(TabbPage.pickerSelectId); });    // вызываемое действие
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
            
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    var translateY = Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs(10 - Height));
                    Filler.TranslateTo(bottomSheet.X, translateY + (Height-bottomSheet.Height+65), 40);
                    bottomSheet.TranslateTo(bottomSheet.X, translateY, 40);
                    break;
                case GestureStatus.Completed:
                    y = bottomSheet.TranslationY;
                    if ((Math.Abs(y) > Height / 20) && !PanelVisible)
                    {
                            bottomSheet.TranslateTo(bottomSheet.X, -(Height - 160), 50);
                            Filler.TranslationY = 0;
                            Filler.TranslateTo(bottomSheet.X, 65, 50);
                            PanelVisible = true;
                    }
                    else
                    {
                        if (PanelVisible)
                        {
                            bottomSheet.TranslateTo(bottomSheet.X, 50, 1);
                            Filler.TranslateTo(bottomSheet.X, Height - 20, 1);
                            PanelVisible = false;
                        }
                        else
                        {
                            bottomSheet.TranslateTo(bottomSheet.X, 50, 1);
                            Filler.TranslateTo(bottomSheet.X, Height - 20, 1);
                        }
                    }
                    break;
                    
            }
        }

       
        private void Weeklist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Weeklist.SelectedItem = null;
        }
    }
}