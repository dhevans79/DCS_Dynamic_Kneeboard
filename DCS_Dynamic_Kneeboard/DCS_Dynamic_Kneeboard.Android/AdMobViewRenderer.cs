using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Ads;

using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using DCS_Dynamic_Kneeboard;
using DCS_Dynamic_Kneeboard.Droid;


[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobViewRenderer))]
namespace DCS_Dynamic_Kneeboard.Droid
{
    class AdMobViewRenderer : ViewRenderer<AdMobView, AdView>
    {

        string adUnitId = "ca-app-pub-3940256099942544/6300978111"; // TEST AD, MY AD = "ca-app-pub-9734939407232570/1523980297";
        AdSize adSize = AdSize.SmartBanner;
        AdView adView;

        public AdMobViewRenderer(Context context) : base(context) {

            
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                SetNativeControl(CreateAdView());
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(AdView.AdUnitId))
                Control.AdUnitId = Element.AdUnitId;
        }

        private AdView CreateAdView()
        {
            if (adView != null)
                return adView;

            adView = new AdView(Forms.Context);
            adView.AdSize = adSize;
            adView.AdUnitId = adUnitId;
            var adParams = new LinearLayout.LayoutParams(
                LayoutParams.WrapContent, LayoutParams.WrapContent);
            adView.LayoutParameters = adParams;

            adView.LoadAd(new AdRequest.Builder().Build());

            return adView;
        }
    }
}