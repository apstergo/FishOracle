using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fishphone
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            Detail = new NavigationPage(new Parser());
            IsPresented = true;
        }

        private void ButtonPars_click(object sender,EventArgs e)
        {
            Detail = new NavigationPage(new Parser());
            IsPresented = false;
        }
        private void ButtonNews_click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new News());
            IsPresented = false;
        }
        private void ButtonFed_click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Feedback());
            IsPresented = false;
        }
        private void ButtonMan_click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Manual());
            IsPresented = false;
        }
    }
}
