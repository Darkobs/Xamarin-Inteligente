using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinInteligente.Services.Interfaces;
using XamarinInteligente.Services.Requests;

namespace XamarinInteligente.Services.Rest
{
    class AccountService : BaseApiServices, IAccountService
    {
        public async Task<bool> CreateUser(string email, string address, string password, string name, string phoneNumber)
        {
            bool result = false;

            CreateUserRequest userRequest = new CreateUserRequest(email, address, password, name, phoneNumber);

            string jsonUserRequest = JsonConvert.SerializeObject(userRequest);

            StringContent stringContent = new StringContent(jsonUserRequest, System.Text.Encoding.UTF8, "application/json");

            string uri = $"{Model.Constants.ServiceConstants.API}api/Account/Register";

            InitHttpClient();
            using (var responseMessage = await httpClient.PostAsync(uri, stringContent))
            {
                if (responseMessage.IsSuccessStatusCode) //responseMessage.StatusCode //responseMessage.EnsureSuccessStatusCode
                    result = true;
            }
            
            return result;
        }
    }
}
