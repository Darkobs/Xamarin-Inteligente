using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinInteligente.Model.BaseTypes;

namespace XamarinInteligente.Controls
{
    public class RouteMap : Map
    {
        public static readonly BindableProperty RouteProperty =
            BindableProperty.Create(nameof(Route), typeof(IEnumerable<Position>), typeof(RouteMap));

        public IEnumerable<Position> Route
        {
            get => (IEnumerable<Position>)GetValue(RouteProperty);
            set => SetValue(RouteProperty, value);
        }

        public static readonly BindableProperty ColorPinsProperty =
            BindableProperty.Create(nameof(ColorPins), typeof(IEnumerable<ColorPin>), typeof(RouteMap));
        public IEnumerable<ColorPin> ColorPins
        {
            get => (IEnumerable<ColorPin>)GetValue(ColorPinsProperty);
            set => SetValue(ColorPinsProperty, value);
        }

        public void FinishRenderer()
        {
            MoveToRegion(MapSpan.FromCenterAndRadius(Route.First(), Distance.FromKilometers(15)));
            //MoveToRegion(MapSpan.FromCenterAndRadius(Route.First(), Distance.FromKilometers(1)));

            ColorPins = new List<ColorPin>();

            (ColorPins as IList).Add(new ColorPin
            {
                Color = Color.Blue,
                Label = "Origen",
                Position = Route.First()
            });

            (ColorPins as IList).Add(new ColorPin
            {
                Color = Color.Red,
                Label = "Destino",
                Position = Route.Last()
            });
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if(propertyName.Equals(nameof(Route)))
            {
                if(Route != null && Route.Any())
                {
                    Polyline polyline = new Polyline
                    {
                        StrokeColor = Color.Red,
                        StrokeWidth = 3
                    };

                    foreach(var coor in Route)
                    {
                        polyline.Geopath.Add(coor);
                    }

                    MapElements.Clear();
                    MapElements.Add(polyline);
                }
            }
        }

        public RouteMap()
        {
        }
    }

    public class ColorPin
    {
        public string Label { get; set; }
        public Position Position { get; set; }
        public Color Color { get; set; }
    }

    public class RouteInfo : ObservableObject
    {
        private Position source;
        public Position Source
        {
            get => source;
            set => SetProperty(ref source, value);
        }

        private Position destination;
        public Position Destination
        {
            get => source;
            set => SetProperty(ref destination, value);
        }
    }
}
