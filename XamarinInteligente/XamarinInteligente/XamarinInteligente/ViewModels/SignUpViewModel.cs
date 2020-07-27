using System;
using System.Collections.Generic;
using System.Text;
using XamarinInteligente.Model.BaseTypes;
using XamarinInteligente.Model.Entities;

namespace XamarinInteligente.ViewModels
{
    class SignUpViewModel : BaseViewModel
    {
        public SignUpViewModel()
        {
            Title = "Nuevo usuario";
            User = new User();
            User = Sampledata.SampleDataGenerator.GenerateUser();
        }

        private User user;

        public User User
        {
            get => user;

            set => SetProperty(ref user, value);
        }
    }
}
