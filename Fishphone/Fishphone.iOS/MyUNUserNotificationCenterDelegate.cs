using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using UserNotifications;

namespace Fishphone.iOS
{
    public class MyUNUserNotificationCenterDelegate : UNUserNotificationCenterDelegate
    {
        bool toggle;
        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            if (toggle)
                completionHandler(UNNotificationPresentationOptions.Alert);
            else
            {
                Console.WriteLine(notification);
                completionHandler(UNNotificationPresentationOptions.None);
            }
            toggle = !toggle;
        }
    }
}