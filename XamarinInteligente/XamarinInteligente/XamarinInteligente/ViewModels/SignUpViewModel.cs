using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinInteligente.Model.BaseTypes;
using XamarinInteligente.Model.Entities;
using XamarinInteligente.Services.Interfaces;
using XamarinInteligente.Services.Rest;

namespace XamarinInteligente.ViewModels
{
    class SignUpViewModel : BaseViewModel
    {
          public SignUpViewModel()
        {
            Title = "Nuevo usuario";
            User = new User();
            IsBusy = false;
            InitVM();


            //User = Sampledata.SampleDataGenerator.GenerateUser();

            //IsBusy = true;
            //Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            //{
            //    IsBusy = !IsBusy;

            //    return true;
            //} );
        }

        private bool isValidEmail;
        public bool IsValidEmail
        {
            get => isValidEmail;
            set
            {
                SetProperty(ref isValidEmail, value);
                ValidateAll();
            }
        }

        private bool isValidPhoneNumber;
        public bool IsValidPhoneNumber
        {
            get => isValidPhoneNumber;
            set
            {
                SetProperty(ref isValidPhoneNumber, value);
                ValidateAll();
            }
        }

        private bool isValidPassword;
        public bool IsValidPassword
        {
            get => isValidPassword;
            set
            {
                SetProperty(ref isValidPassword, value);
                ValidateAll();
            }
            
        }

        private User user;
        public User User
        {
            get => user;
            set => SetProperty(ref user, value);
        }

        private bool isValid;
        public bool IsValid
        {
            get => isValid;
            set => SetProperty(ref isValid, value);
        }

        private void CleanData()
        {
            User.Name = string.Empty;
            User.Password = string.Empty;
            User.PhoneNumber = string.Empty;
            User.Address = string.Empty;
            User.Email = string.Empty;
        }

        private void ValidateAll() 
            => IsValid = IsValidEmail && IsValidPassword && IsValidPhoneNumber;

        private async Task CreateUser()
        {
            if (Xamarin.Essentials.Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Internet)
            {
                if (!IsBusy)
                {
                    IsBusy = true;
                    IAccountService accountService = new AccountService();

                    bool result = await accountService.CreateUser(user.Email, user.Address, user.Password, user.Name, user.PhoneNumber);

                    string message = result ? "El usuario se creó correctamente" : "Hubo un error";

                    Application.Current.MainPage.DisplayAlert("Creación de usuario", message, "Aceptar");

                    if (result)
                    {
                        CleanData();
                        var tabbedPage = (Application.Current.MainPage as NavigationPage).CurrentPage as TabbedPage;
                        tabbedPage.SelectedItem = tabbedPage.Children[0];
                    }

                    IsBusy = false;
                }
            }
            else
                await Application.Current.MainPage.DisplayAlert("Creación de usuario", "Se requiere Internet para continuar", "Aceptar");

            //if(!IsBusy)
            //{
            //    IsBusy = true;

            //    if(IsValid && !string.IsNullOrWhiteSpace(User.Name) && !string.IsNullOrWhiteSpace(User.Address))
            //    {
            //        await Task.Delay(5000);
            //        await Application.Current.MainPage.DisplayAlert("Nuevo usuario creado", "El usuario se creaó correctamente", "Continuar");
            //        CleanData();
            //        var tabbedPage = (Application.Current.MainPage as NavigationPage).CurrentPage as TabbedPage;
            //        tabbedPage.SelectedItem = tabbedPage.Children[0];
            //    }

            //    IsBusy = false;
            //}
        }

        public Command CreateUserCommand
        {
            get;
            set;
        }

        //public Command CreateUserCommand => new Command(async () => await CreateUser());

        void InitVM()
        {
            CreateUserCommand = new Command(async () => await CreateUser());
            CleanData();
        }
    }
}
