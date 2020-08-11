using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinInteligente.Services.WebApiServices.ResponseClasses
{
    public class TokenResponse
    {
        [JsonProperty("Access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("Token_type")]
        public string TokenType { get; set; }
        [JsonProperty("Expires_in")]
        public string ExpiresIn { get; set; }
        public string Username { get; set; }
        [JsonProperty(".issued")]
        public string Issued { get; set; }
        [JsonProperty(".expires")]
        public string Expires { get; set; }
        public string Error { get; set; }
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
