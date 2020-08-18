using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace XamarinInteligente.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NextClientPage : ContentPage
    {
        public NextClientPage()
        {
            InitializeComponent();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(19.4485455, -99.1724404), Distance.FromKilometers(10)));
        }
    }
}