using MapKit;
using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;
using XamarinInteligente.Controls;
using XamarinInteligente.iOS.Renderer;

[assembly:ExportRenderer(typeof(RouteMap), typeof(RouteMapRenderer))]
namespace XamarinInteligente.iOS.Renderer
{
    public class ColorPointAnnotation : MKPointAnnotation
    {
        public UIColor Color
        {
            get;
            private set;
        }

        public ColorPointAnnotation(UIColor color)
        {
            Color = color;
        }
    }

    public class RouteMapRenderer : MapRenderer
    {
        public RouteMapRenderer()
        {
            
        }

        MKPolylineRenderer polylineRenderer;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if(e.OldElement != null)
            {
                var nativeMap = Control as MKMapView;

                if(nativeMap != null && nativeMap.Overlays != null)
                {
                    nativeMap.RemoveOverlays(nativeMap.Overlays);
                    nativeMap.OverlayRenderer = null;
                    polylineRenderer = null;
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if(e.PropertyName.Equals(nameof(RouteMap.Route)))
            {
                var nativeMap = Control as MKMapView;
                nativeMap.RemoveAnnotations(nativeMap.Annotations);

                var formsMap = Element as RouteMap;

                formsMap.FinishRenderer();

                foreach(var pin in formsMap.ColorPins)
                {
                    var annotation = CreateAnnotation(pin);
                    nativeMap.AddAnnotation(annotation);
                }
            }
        }

        IMKAnnotation CreateAnnotation(ColorPin pin)
        {
            var annotation = new ColorPointAnnotation(pin.Color.ToUIColor())
            {
                Title = pin.Label,
                Subtitle = "",
                Coordinate = new CoreLocation.CLLocationCoordinate2D(pin.Position.Latitude, pin.Position.Longitude)
            };

            return annotation;
        }

        protected override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            var colorAnnotation = annotation as ColorPointAnnotation;

            MKPinAnnotationView view = null;

            if(colorAnnotation != null)
            {
                var identifier = "colorAnnotation";

                view = mapView.DequeueReusableAnnotation(identifier) as MKPinAnnotationView;

                if(view == null)
                {
                    view = new MKPinAnnotationView(colorAnnotation, identifier);
                }

                view.CanShowCallout = true;
                view.PinTintColor = colorAnnotation.Color;
            }

            return view;
        }
    }
}