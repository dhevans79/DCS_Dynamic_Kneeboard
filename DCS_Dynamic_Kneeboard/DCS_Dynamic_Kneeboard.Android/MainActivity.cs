using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Ads;
using Xamarin.Forms;

namespace DCS_Dynamic_Kneeboard.Droid
{
    // Removed mainLauncher attribute whilst testing splash screen
    //[Activity(Label = "DCS_Dynamic_Kneeboard", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [Activity(Label = "DCS_Dynamic_Kneeboard", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            string adMobAppID = "ca-app-pub-9734939407232570~5682717153";

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            MobileAds.Initialize(ApplicationContext, adMobAppID);

            LoadApplication(new App());
        }
    }
}

