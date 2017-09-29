using System;
using Foundation;
using LeanplumBindings;
using LeanplumDemo.Common;
using LeanplumDemo.Helpers;
using UIKit;

namespace LeanplumDemo
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public static string Email { get; private set; }
        public static string Password { get; private set; }

        public static Action OnOpenFromDeepLinking { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method

            Leanplum.SetDevelopmentAppId(Constants.LEANPLUM_APP_ID, Constants.LEANPLUM_DEV_APP_KEY);
            Leanplum.Start();

            return true;
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            var parsedOptions = QueryStringHelper.ParseQueryString(url.Query, "&");
            if (parsedOptions.ContainsKey(Constants.EMAIL_KEY))
            {
                Email = parsedOptions[Constants.EMAIL_KEY];
            }

            if (parsedOptions.ContainsKey(Constants.PASSWORD_KEY))
            {
                Password = parsedOptions[Constants.PASSWORD_KEY];
            }

            OnOpenFromDeepLinking?.Invoke();

            return true;
        }

        #region boiler plate code

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }

        #endregion

    }
}

