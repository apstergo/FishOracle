using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using Plugin.Settings;
using System.Reactive.Linq;

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
                BarBackgroundColor = Color.FromRgb(69, 71, 82)
            };
            Akavache.Registrations.Start("AkavacheExperiment");
        }

        protected override void OnStart()
        {
            AppCenter.Start("af0ea426-9f12-4070-a8a7-8d776f338151", typeof(Push));
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
