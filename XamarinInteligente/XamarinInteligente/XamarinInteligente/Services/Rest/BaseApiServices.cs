using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace XamarinInteligente.Services
{
    class BaseApiServices
    {
        protected static HttpClient httpClient;

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
