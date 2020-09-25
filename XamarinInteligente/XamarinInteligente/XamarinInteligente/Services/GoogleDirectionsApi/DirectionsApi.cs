using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinInteligente.Services.GoogleDirectionsApi.Responses;
using XamarinInteligente.Model.Constants;
using Newtonsoft.Json;

namespace XamarinInteligente.Services.GoogleDirectionsApi
{
    public class DirectionsApi
    {
        static HttpClient httpClient = new HttpClient();

        public async static Task<GoogleDirectionsResponse> GetDirectionsResponse(string origin, string destination)
        {
            string url = string.Format(GoogleDirectionsConstants.URI, origin, destination, GoogleDirectionsConstants.APIKEY);

            using (var response = await httpClient.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    var predictions = JsonConvert.DeserializeObject<GoogleDirectionsResponse>
                        (await response.Content.ReadAsStringAsync());
                    return predictions;
                }
            }
            return null;
        }
    }

    
}
