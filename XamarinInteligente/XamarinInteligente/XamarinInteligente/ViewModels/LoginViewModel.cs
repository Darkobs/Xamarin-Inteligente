﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinInteligente.Model.BaseTypes;
using XamarinInteligente.Views;

namespace XamarinInteligente.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        public LoginViewModel() :base()
        {
            InitVM();
            CleanData();
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

        public Command LoginCommand
        {
            get;
            set;
        }

        public Command SignUpCommand
        {
            get;
            set;
        }

        private void InitVM()
        {
            LoginCommand = new Command(async () => await Login());
            SignUpCommand = new Command(async () => await SignUp());
        }

        private async Task Login()
        {
            if(!IsBusy)
            {
                IsBusy = true;

                if(!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
                {
                    await Task.Delay(5000);
                    Application.Current.MainPage = new MainMasterDetailPage();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Por favor revisa los datos introducidos", "Aceptar");
                }
                CleanData();
                IsBusy = false;
            }
        }

        private async Task SignUp()
        {
            if(!IsBusy)
            {
                IsBusy = true;
                var tabbedPage = (Application.Current.MainPage as NavigationPage).CurrentPage as TabbedPage;
                tabbedPage.SelectedItem = tabbedPage.Children[1];
                IsBusy = false;
            }
        }

        private void CleanData()
        {
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}