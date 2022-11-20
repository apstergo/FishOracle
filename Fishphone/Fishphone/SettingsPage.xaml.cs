using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Settings;
using Microsoft.AppCenter.Push;
using Microsoft.AppCenter;

namespace Fishphone
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
        public  string[] city_short = new string[] { "msc", "spb", "alt", "amu", "arh", "ast", "belg", "br", "vlad", "volggr", "volgdn", "vor", "eat", "zab", "ivan", "irkut", "kaliningrad", "kalugь", "kamch", "kemer", "kir", "kost", "karasnodar", "krasnoyarsk", "kurg", "kursk", "lenobl", "lip", "magadan", "mscobl", "murm", "NAO", "nijgor", "novgor", "novosib", "omsk", "orenb", "orl", "penz", "perm", "prim", "pskov", "adigeya", "alt", "bashk", "burat", "dag", "ing", "karcher", "kabbal", "kalm", "karel", "komi", "krim", "marial", "mord", "saha", "sevos", "tat", "tiva", "udmurt", "hakasia", "chechnia", "chuv", "rost", "rias", "sam", "sar", "sahalin", "sverd", "smol", "stav", "tamb", "tver", "tomsk", "tulsk", "tum", "ulyan", "hab", "yugra", "chel", "chukot", "yanao", "yaroslavsk" };

        public SettingsPage ()
		{
			InitializeComponent ();
            picker.SelectedIndex = CrossSettings.Current.GetValueOrDefault("DefaultCity", 0);
            CacheDate.Text = "Последнее обновление кэша: "+CrossSettings.Current.GetValueOrDefault("ChacheDate", DateTime.Today).ToString();
            switchpush.IsToggled = CrossSettings.Current.GetValueOrDefault("PushON", true);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CrossSettings.Current.GetValueOrDefault("PushON", true))
                {
                    DependencyService.Get<ISubcribePush>().UnSubcribe(city_short[CrossSettings.Current.GetValueOrDefault("DefaultCity", 0)]);
                    DependencyService.Get<ISubcribePush>().Subcribe(city_short[picker.SelectedIndex]);
                }
                CrossSettings.Current.AddOrUpdateValue("DefaultCity", picker.SelectedIndex);
            }
            catch
            {

            }

        }

        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                CrossSettings.Current.AddOrUpdateValue("PushON", true);
                int city = CrossSettings.Current.GetValueOrDefault("DefaultCity", 0);
                DependencyService.Get<ISubcribePush>().Subcribe(city_short[city]);
            }
            else
            {
                CrossSettings.Current.AddOrUpdateValue("PushON", false);
                int city = CrossSettings.Current.GetValueOrDefault("DefaultCity", 0);
                DependencyService.Get<ISubcribePush>().UnSubcribe(city_short[city]);
            }
        }
    }
}