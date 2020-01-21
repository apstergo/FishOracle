using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fishphone
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Manual : ContentPage
	{
		public Manual ()
		{
			InitializeComponent ();
            baner.Source = null;
            baner.Source = new UriImageSource { CachingEnabled = true, Uri = new Uri("http://ribakiriba.ru/advertisingplace.png") };
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new ManualAll(1));
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManualAll(2));
        }

        private async void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManualAll(3));
        }

        private async void ImageButton_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManualAll(4));
        }

        private void Baner_Clicked(object sender, EventArgs e)
        {

        }
    }
}