using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using Plugin.Settings;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Fishphone
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TabbPage())
            {
                BarBackgroundColor = Color.FromRgb(69, 71, 82),
                BarTextColor=Color.White
            };

            Akavache.Registrations.Start("AkavacheExperiment");
        }

        

        protected override void OnStart()
        {
            AppCenter.Start("android=" +
                  "uwp={Your UWP App secret here};" +
                  "ios=",
                  typeof(Analytics), typeof(Crashes));
            Crashes.NotifyUserConfirmation(UserConfirmation.AlwaysSend);
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
