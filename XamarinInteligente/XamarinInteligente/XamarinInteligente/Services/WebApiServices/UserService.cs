using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinInteligente.Model.Entities;
using XamarinInteligente.Services.Interfaces;
using XamarinInteligente.Services.WebApiServices.ResponseClasses;

namespace XamarinInteligente.Services.WebApiServices
{
    class UserService : BaseApiServices, IUserService
    {
        public UserService()
        {

        }

        public async Task<LoginStatus> Login(User user)
        {
            LoginStatus result = LoginStatus.Error;
            Dictionary<string, string> requestContent = new Dictionary<string, string>();
            requestContent.Add("UserName", user.Email);
            requestContent.Add("Password", user.Password);
            requestContent.Add("grant_type", "password");

            string uri = $"{Model.Constants.ServiceConstants.API}token";
            ResponseClasses.TokenResponse tokenResponse;
            InitHttpClient();
            using (HttpResponseMessage response = await httpClient.PostAsync(uri, new FormUrlEncodedContent(requestContent)))
            using (HttpContent content = response.Content)
            {
                if (response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    string responseStringContent = await content.ReadAsStringAsync();
                    tokenResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseClasses.TokenResponse>(responseStringContent);
                    if (!string.IsNullOrWhiteSpace(tokenResponse.Error))
                    {
                        switch (tokenResponse.Error)
                        {
                            case "invalid_grant":
                                result = LoginStatus.UserPasswordError;
                                break;
                            case "before_locked_out":
                                result = LoginStatus.LastLoginBeforeBlock;
                                break;
                            case "locked_out":
                                result = LoginStatus.Blocked;
                                break;
                        }
                    }
                    else
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            result = LoginStatus.Ok;
                            accessToken = tokenResponse.AccessToken;
                            accessTokenType = tokenResponse.TokenType;
                        }
                    }
                }
            }

            return result;
        }
        public async Task<User> GetUserInfo(User user)
        {
            User result = null;
            string uri = $"{Model.Constants.ServiceConstants.API}api/Account/UserInfo";
            ResponseClasses.TokenResponse tokenResponse;

            InitHttpClient();
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(accessTokenType, accessToken);
                using (HttpResponseMessage response = await httpClient.SendAsync(request))
                {
                    using(HttpContent content = response.Content)
                    {
                        string responseStringContent = await content.ReadAsStringAsync();
                        var userInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseClasses.UserInfoResponse>(responseStringContent);

                        if(response.IsSuccessStatusCode)
                        {
                            result = new User
                            {
                                Address = userInfo.Address,
                                Name = userInfo.Name,
                                Email = user.Email
                            };
                        }
                    }
                }
            }

            return result;
        }

        public async Task<bool> Logout(User user)
        {
            bool result = false;
            accessToken = string.Empty;
            accessTokenType = string.Empty;
            result = true;
            return result;
        }
    }
}
