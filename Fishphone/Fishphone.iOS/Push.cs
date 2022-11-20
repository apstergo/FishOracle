using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using UserNotifications;
using Firebase.CloudMessaging;
using Xamarin.Forms;
using Fishphone.iOS;
using System.Diagnostics;

[assembly: Dependency(typeof(Push))]
namespace Fishphone.iOS
{
    class Push : ISubcribePush
    {
        public void Subcribe(string key)
        {
            try
            {
                Messaging.SharedInstance.Subscribe(key);
            }
            catch(Exception ex)
            {

                Debug.WriteLine(ex.ToString());
            }
            
        }
        public void UnSubcribe(string key)
        {
            Messaging.SharedInstance.Unsubscribe(key);
        }
    }
}