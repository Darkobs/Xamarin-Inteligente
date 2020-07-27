using System;
using System.Collections.Generic;
using System.Text;
using XamarinInteligente.Model.BaseTypes;

namespace XamarinInteligente.Model.Entities
{
    public enum ClientStatus
    {
        Ok,
        Debt,
        Blocked
    }

    class Client : ObservableObject
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

            set => SetProperty(ref address, value); // name = value;
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get => phoneNumber;

            set => SetProperty(ref phoneNumber, value); // name = value;
        }

        private string email;

        public string Email
        {
            get => email;

            set => SetProperty(ref email, value); // name = value;
        }

        private string clientId;

        public string ClientId
        {
            get => clientId;

            set => SetProperty(ref clientId, value); // name = value;
        }

        private ClientStatus clientStatus;

        public ClientStatus ClientStatus
        {
            get => clientStatus;

            set => SetProperty(ref clientStatus, value); // name = value;
        }
    }
}
