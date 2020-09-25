using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinInteligente.Model.BaseTypes;
using XamarinInteligente.Services.Interfaces;
using XamarinInteligente.Services.WebApiServices;

namespace XamarinInteligente.ViewModels
{
    public class SplashScreenViewModel : BaseViewModel
    {
        public async Task<bool> Login()
        {
            bool result = false;

            if(App.Current.Properties.ContainsKey("KeepLogin"))
            {
                if(App.Current.Properties["KeepLogin"] is bool keeplogin && keeplogin)
                {
                    try 
                    {
                        var accessToken = App.Current.Properties["AccessToken"] as string;
                        var accessTokenType = App.Current.Properties["AccessTokenType"] as string;
                        IUserService userService = new UserService(accessToken, accessTokenType);
                        var userInfo = await userService.GetUserInfo();

                        result = userInfo != null;
                    }
                    catch
                    {
                        result = false;
                    }
                }
            }

            return result;
        }
    }
}
