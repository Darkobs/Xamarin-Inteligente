using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinInteligente.Model.BaseTypes;
using XamarinInteligente.Model.Entities;

namespace XamarinInteligente.ViewModels
{
    class NextClientViewModel : BaseViewModel
    {
        public NextClientViewModel()
        {
            Title = "Siguiente Cliente";
            InitViewModel();

            Client = new Client();
            Client = Sampledata.SampleDataGenerator.GenerateClient();
        }

        private Client client;

        public Client Client
        {
            get => client;

            set => SetProperty(ref client, value);
        }

        async Task InitViewModel()
        {
            await GetLocation();
        }

        private async Task GetLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(30));
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

                    CurrentLocation = new Position(location.Latitude, location.Longitude);
                }
            }

            catch (Exception ex)
            {
                // Unable to get location
                Debug.WriteLine(ex.Message);
            }
        }

        private Position currentLocation;

        public Position CurrentLocation
        {
            get => currentLocation;
            set => SetProperty(ref currentLocation, value);
        }

        private List<Position> route;

        public List<Position> Route
        {
            get => route;
            set => SetProperty(ref route, value);
        }

        public Command ShowRouteCommand => new Command(() =>
        {
            var route = new List<Position>
            {
                new Position(19.480859700649, -99.116198856044),
                new Position(19.480868713337, -99.116223798012),
                new Position(19.480877726026, -99.116248739979),
                new Position(19.480886738714, -99.116273681947),
                new Position(19.480895751402, -99.116298623914),
                new Position(19.48090476409, -99.116323565882),
                new Position(19.480913776778, -99.116348507849),
                new Position(19.480922789466, -99.116373449817),
                new Position(19.480931802154, -99.116398391785),
                new Position(19.480940814842, -99.116423333752),
                new Position(19.48094982753, -99.11644827572),
                new Position(19.480958840218, -99.116473217687),
                new Position(19.480967852907, -99.116498159655),
                new Position(19.480976865595, -99.116523101622),
                new Position(19.480985878283, -99.11654804359),
                new Position(19.480994890971, -99.116572985557),
                new Position(19.481003903659, -99.116597927525),
                new Position(19.481012916347, -99.116622869493),
                new Position(19.481021929035, -99.11664781146),
                new Position(19.481030941723, -99.116672753428),
                new Position(19.481039954411, -99.116697695395),
                new Position(19.4810489671, -99.116722637363),
                new Position(19.481057979788, -99.11674757933),
                new Position(19.481066992476, -99.116772521298),
                new Position(19.481076005164, -99.116797463265),
                new Position(19.481085017852, -99.116822405233),
                new Position(19.48109403054, -99.116847347201),
                new Position(19.481103043228, -99.116872289168),
                new Position(19.481112055916, -99.116897231136),
                new Position(19.481121068604, -99.116922173103),
                new Position(19.481130081292, -99.116947115071),
                new Position(19.481139093981, -99.116972057038),
                new Position(19.481148106669, -99.116996999006),
                new Position(19.481157119357, -99.117021940973),
                new Position(19.481166132045, -99.117046882941),
                new Position(19.481175144733, -99.117071824908),
                new Position(19.481184157421, -99.117096766876),
                new Position(19.481193170109, -99.117121708844),
                new Position(19.481202182797, -99.117146650811),
                new Position(19.481211195485, -99.117171592779),
                new Position(19.481220208174, -99.117196534746),
                new Position(19.481229220862, -99.117221476714),
                new Position(19.48123823355, -99.117246418681),
                new Position(19.481247246238, -99.117271360649),
                new Position(19.481256258926, -99.117296302616),
                new Position(19.481265271614, -99.117321244584),
                new Position(19.481274284302, -99.117346186552),
                new Position(19.48128329699, -99.117371128519),
                new Position(19.481292309678, -99.117396070487),
                new Position(19.481301322367, -99.117421012454),
                new Position(19.481310335055, -99.117445954422),
                new Position(19.481319347743, -99.117470896389),
                new Position(19.481328360431, -99.117495838357),
                new Position(19.481337373119, -99.117520780324),
                new Position(19.481346385807, -99.117545722292),
                new Position(19.481355398495, -99.11757066426),
                new Position(19.481364411183, -99.117595606227),
                new Position(19.481373423871, -99.117620548195),
                new Position(19.481382436559, -99.117645490162),
                new Position(19.481391449248, -99.11767043213),
                new Position(19.481400461936, -99.117695374097),
                new Position(19.481409474624, -99.117720316065),
                new Position(19.481418487312, -99.117745258032),
                new Position(19.4814275, -99.1177702)
            };

            Route = route;
        });
    }
}
