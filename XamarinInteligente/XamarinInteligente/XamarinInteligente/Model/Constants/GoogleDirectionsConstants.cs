using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinInteligente.Model.Constants
{
    public class GoogleDirectionsConstants
    {
        public const string APIKEY = "AIzaSyDE1xM4o4G6mF7ODW7zp4JSogk6LaCNcvg";

        public const string URI = "https://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}&avoid=highways&mode=walking&key={2}";
    }
}
