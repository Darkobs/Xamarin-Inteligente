using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using XamarinInteligente.Model.BaseTypes;
using XamarinInteligente.Model.Entities;

namespace XamarinInteligente.ViewModels
{
    class NextClientViewModel : BaseViewModel
    {
        public NextClientViewModel()
        {
            Title = "Siguiente Cliente";
            Client = new Client();
            Client = Sampledata.SampleDataGenerator.GenerateClient();
        }

        private Client client;

        public Client Client
        {
            get => client;

            set => SetProperty(ref client, value);
        }
    }
}
