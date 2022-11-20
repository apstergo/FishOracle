using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Fishphone;
using Fishphone.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AdInterstitial_Droid))]
namespace Fishphone.Droid
{
    public class AdInterstitial_Droid : AdListener, IAdInterstitial
    {
        InterstitialAd interstitialAd;

        public AdInterstitial_Droid()
        {
            interstitialAd = new InterstitialAd(Android.App.Application.Context);

            // TODO: change this id to your admob id  
            interstitialAd.AdUnitId = "";

            LoadAd();
        }

        public void LoadAd()
        {
            var requestbuilder = new AdRequest.Builder();
            interstitialAd.LoadAd(requestbuilder.Build());
            //Toast.MakeText(Android.App.Application.Context, "Load", ToastLength.Short).Show();
        }
        public override void OnAdLoaded()
        {
            base.OnAdLoaded();

        }
        public override void OnAdFailedToLoad(int errorCode)
        {
            base.OnAdFailedToLoad(errorCode);
           

        }

        public void ShowAd()
        {
            if (interstitialAd.IsLoaded)
            {
                interstitialAd.Show();
                //Toast.MakeText(Android.App.Application.Context, "Show", ToastLength.Short).Show();
            }
            
            LoadAd();

        }
    }
}