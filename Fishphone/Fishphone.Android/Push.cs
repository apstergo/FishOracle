using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;
using Fishphone.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(Push))]
namespace Fishphone.Droid
{
    public class Push:ISubcribePush
    {
        public void Subcribe(string key)
        {
            FirebaseMessaging.Instance.SubscribeToTopic(key);
        }
        public void UnSubcribe(string key)
        {
            FirebaseMessaging.Instance.UnsubscribeFromTopic(key);
        }
    }
}