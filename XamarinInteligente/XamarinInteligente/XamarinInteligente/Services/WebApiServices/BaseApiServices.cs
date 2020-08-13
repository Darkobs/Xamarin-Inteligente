using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace XamarinInteligente.Services
{
    public class BaseApiServices
    {
        protected static HttpClient httpClient;
        protected static string accessToken;
        protected static string accessTokenType;

        public BaseApiServices()
        {

        }

        protected void InitHttpClient()
        {
            if(httpClient is null)
            {
                httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromSeconds(Model.Constants.ServiceConstants.TIMEOUT);
            }
        }
    }
}
