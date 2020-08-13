using System;
using System.Collections.Generic;
using System.Text;
using XamarinInteligente.Services.Interfaces;
using XamarinInteligente.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XamarinInteligente.Model.Entities;
using Xamarin.Forms;
using System.Net.Http;
using System.Linq;

namespace XamarinInteligente.Services.WebApiServices
{
    public class ProductService : BaseApiServices, IProductsService
    {
        public ProductService()
        {
        }

        public async Task<ObservableCollection<Product>> GetAllProducts()
        {
            ObservableCollection<Product> result = null;

            //Obtenemos el catalogo almacenado
            result = null;

            //De inicio definimos una fecha al azar que podría considerarse obsoleta
            var currentLocalVersion = DateTime.Now.ToUniversalTime() - TimeSpan.FromDays(15);

            //Revisamos en el almacenamiento local para validar si ya tenemos una versión almacenada y obtenemos ese valor
            if (Application.Current.Properties.ContainsKey("SavedCatalogVersion"))
                currentLocalVersion = (DateTime)Application.Current.Properties["SavedCatalogVersion"];

            //Obtenemos el valor de la versión que está en la API
            var currentOnlineVersion = await GetProductCatalogVersion();


            string uri = $"{Model.Constants.ServiceConstants.API}api/products";

            InitHttpClient();
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(accessTokenType, accessToken);
                using (HttpResponseMessage response = await httpClient.SendAsync(request))//.SendAsync(request))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string responseStringContent = await content.ReadAsStringAsync();
                            result = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Product>>(responseStringContent);

                            //Si logramos obtener los datos, los almacenamos en SQLite
                            Application.Current.Properties["SavedCatalogVersion"] = currentOnlineVersion;

                            //Finalmente aplicamos los cambios
                            await Application.Current.SavePropertiesAsync();
                        }
                    }
                }

            }

            return result;
        }

        public async Task<Product> GetProductById(string productId)
        {
            Product result = null;
            string uri = $"{Model.Constants.ServiceConstants.API}api/products/{productId}";

            InitHttpClient();
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(accessTokenType, accessToken);
                using (HttpResponseMessage response = await httpClient.SendAsync(request))//.SendAsync(request))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string responseStringContent = await content.ReadAsStringAsync();
                            result = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(responseStringContent);
                        }
                    }
                }
            }
            return result;
        }

        public async Task<DateTime> GetProductCatalogVersion()
        {
            DateTime result = DateTime.Now;
            string uri = $"{Model.Constants.ServiceConstants.API}api/products/version";

            InitHttpClient();
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(accessTokenType, accessToken);
                using (HttpResponseMessage response = await httpClient.SendAsync(request))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string responseStringContent = await content.ReadAsStringAsync();
                            result = Newtonsoft.Json.JsonConvert.DeserializeObject<DateTime>(responseStringContent).ToUniversalTime();

                        }
                    }
                }
            }
            return result;
        }


        public async Task<ObservableCollection<Product>> LookForProducts(string query)
        {
            ObservableCollection<Product> result = null;

            var products = await GetAllProducts();

            result = new ObservableCollection<Product>(
                products.Where((product) => product.Name.ToLower().Contains(query.ToLower())));
            return result;
        }
    }
}
