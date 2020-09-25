using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinInteligente.Droid.Renderer;

[assembly: ExportRenderer(typeof(XamarinInteligente.Controls.AdView), typeof(AdViewRenderer))]
namespace XamarinInteligente.Droid.Renderer
{
    public class AdViewRenderer : ViewRenderer
    {
        string adUnit = string.Empty;
        AdSize adSize = AdSize.SmartBanner;
        AdView adView;

        public AdViewRenderer(Context context) : base (context)
        {

        }

        protected override Android.Views.View CreateNativeControl()
        {
            if (adView != null)
                return adView;
#if DEBUG
            // https://developers.google.com/admob/android/test-ads?hl=es
            adUnit = "ca-app-pub-3940256099942544/6300978111";
#else
            adUnit = "";
#endif
            adView = new AdView(Android.App.Application.Context)
            {
                AdUnitId = adUnit,
                AdSize = adSize
            };

            var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);

            adView.LayoutParameters = adParams;
            adView.LoadAd(new AdRequest.Builder().Build());

            return base.CreateNativeControl();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            if(Control is null)
            {
                CreateNativeControl();
                SetNativeControl(adView);
            }
        }
    }
}