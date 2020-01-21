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
		public SettingsPage ()
		{
			InitializeComponent ();
            picker.SelectedIndex = CrossSettings.Current.GetValueOrDefault("DefaultCity", 0);
            CacheDate.Text = "Последнее обновление кэша: "+CrossSettings.Current.GetValueOrDefault("ChacheDate", DateTime.Today).ToString();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CrossSettings.Current.AddOrUpdateValue("DefaultCity", picker.SelectedIndex);
            }
            catch
            {

            }
            
        }

        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if(e.Value)
            { 
                
            }
            else
            {
                
            }
        }
    }
}