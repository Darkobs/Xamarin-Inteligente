using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinInteligente.Model.BaseTypes;
using XamarinInteligente.Services.Interfaces;

namespace XamarinInteligente.Model.Entities
{
    public enum LoginStatus
    {
        Ok,
        UserPasswordError,
        Blocked,
        Logout,
        Error,
        LastLoginBeforeBlock
    }

    public class User : ObservableObject
    {
        private string name;

        public string Name
        {
            get => name;

            set => SetProperty(ref name, value); // name = value;
        }

        private string address;

        public string Address
        {
            get => address;

            set => SetProperty(ref address, value);
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get => phoneNumber;

            set => SetProperty(ref phoneNumber, value);
        }

        private string email;

        public string Email
        {
            get => email;

            set => SetProperty(ref email, value);
        }

        private string password;

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private IUserService userService = new Services.WebApiServices.UserService();

        public async Task<Tuple<LoginStatus, string>> Login(bool keepLogin)
        {
            var loginStatus = await userService.Login(this);
            Tuple<LoginStatus, string> result = loginStatus;
            if (loginStatus.Item1 == LoginStatus.Ok)
            {
                var userInfo = await userService.GetUserInfo();
                Address = userInfo?.Address;
                Name = userInfo?.Name;
                Email = userInfo?.Email;
                password = string.Empty;
                var userInfoLoginStatus = userInfo == null ? LoginStatus.Error : loginStatus.Item1;
                result = new Tuple<LoginStatus, string>(userInfoLoginStatus, loginStatus.Item2);

                if(keepLogin)
                {
                    var tokenInfo = loginStatus.Item2.Split('|');
                    App.Current.Properties["AccessTokenType"] = tokenInfo[0];
                    App.Current.Properties["AccessToken"] = tokenInfo[1];
                    App.Current.Properties["KeepLogin"] = true;
                    await App.Current.SavePropertiesAsync();
                }
                else
                {
                    App.Current.Properties.Clear();
                    App.Current.Properties["KeepLogin"] = false;
                    await App.Current.SavePropertiesAsync();
                }
            }
            return result;
        }

        public LoginStatus Logout()
        {
            return LoginStatus.Logout;
        }
    }
}
