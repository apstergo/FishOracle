using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Android.Gms.Common;
using Android.Gms.Ads;
using Xamarin.Forms;

namespace Fishphone.Droid
{
    [Activity(Label = "FishOracle", Icon = "@drawable/logo5", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static readonly string TAG = "MainActivity";

        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            if (Device.Idiom == TargetIdiom.Phone)
            {
                this.RequestedOrientation = ScreenOrientation.Portrait;
            }
            if (Device.Idiom == TargetIdiom.TV)
            {
                this.RequestedOrientation = ScreenOrientation.Landscape;
            }
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                this.RequestedOrientation = ScreenOrientation.Landscape;
            }


            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
            {
                Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#454753"));
                Window.SetNavigationBarColor(Android.Graphics.Color.ParseColor("#454753"));
            };
           

            //IsPlayServicesAvailable();
            //CreateNotificationChannel();

            LoadApplication(new App());
        }

        public bool IsPlayServicesAvailable()
        {
            int resultCode = Android.Gms.Common.GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {

                }
                else
                {
                    Finish();
                }
                return false;
            }
            else
            {
                return true;
            }
        }
        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CHANNEL_ID,
                                                  "FCM Notifications",
                                                  NotificationImportance.Default)
            {

                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
    }
}