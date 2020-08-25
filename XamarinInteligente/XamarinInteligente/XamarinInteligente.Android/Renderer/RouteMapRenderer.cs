using System;
using System.ComponentModel;
using Android.Content;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Java.Util.Concurrent.Atomic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;
using XamarinInteligente.Controls;
using XamarinInteligente.Droid.Renderer;

[assembly: ExportRenderer(typeof(RouteMap), typeof(RouteMapRenderer))]
namespace XamarinInteligente.Droid.Renderer
{
    public class RouteMapRenderer : MapRenderer
    {
        public RouteMapRenderer(Context context)
            :base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.GetMapAsync(this);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if(e.PropertyName.Equals(nameof(RouteMap.Route))) // "Route"
            {
                var nativeMap = NativeMap;

                var formsMaps = (RouteMap)Element;

                nativeMap.Clear();

                formsMaps.FinishRenderer();

                foreach(var pin in formsMaps.ColorPins)
                {
                    var marker = new MarkerOptions();
                    marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
                    marker.SetTitle(pin.Label);
                    marker.SetIcon(GetMarkerIcon(ColorExtensions.ToAndroid(pin.Color)));
                    nativeMap.AddMarker(marker);
                }
            }
        }

        public  BitmapDescriptor GetMarkerIcon(Android.Graphics.Color color)
        {
            float[] hsv = new float[3];

            Android.Graphics.Color.ColorToHSV(color, hsv);

            return BitmapDescriptorFactory.DefaultMarker(hsv[0]);
        }
    }
}