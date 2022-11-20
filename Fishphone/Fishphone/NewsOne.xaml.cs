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
    public partial class NewsOne : ContentPage
    {
        public NewsOne(Newscl content)
        {
            InitializeComponent();
            lableTitli.Text = content.titletext;
            lableDate.Text = content.date;
            lableText.Text = content.textnews.Replace("<br />","");
            baner.Source = null;
            baner.Source = new UriImageSource { CachingEnabled = true, Uri = new Uri("") };
            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Transparent;
        }
        protected override bool OnBackButtonPressed()
        {
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromRgb(69, 71, 82);
            return base.OnBackButtonPressed();
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
           
        }

        private void Baner_Clicked(object sender, EventArgs e)
        {

        }
    }
}