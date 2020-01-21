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
	public partial class ManualOne : ContentPage
	{
		public ManualOne (Manualcs content)
		{
			InitializeComponent ();
            lableTitli.Text = content.nameitem;
            lableText.Text = content.opis.Replace("<br />", "");
            Picc.Source = content.pictureref;
            baner.Source = null;
            baner.Source = new UriImageSource { CachingEnabled = true, Uri = new Uri("http://ribakiriba.ru/advertisingplace.png") };
        }

        private void Baner_Clicked(object sender, EventArgs e)
        {

        }
    }
}