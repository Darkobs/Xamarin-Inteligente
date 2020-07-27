using System;
using System.Collections.Generic;
using System.Text;
using XamarinInteligente.Model.Entities;

namespace XamarinInteligente.Sampledata
{
    class SampleDataGenerator
    {
        public static User GenerateUser()
        {
            User user = new User();
            user.Name = "Jose Luis Jimenez";
            user.PhoneNumber = "+52 1 55782837";
            user.Email = "jjimenez@sales.com";
            user.Address = "Pase de la Reforma, Juárez, 06600 Cuauhtémoc, CDMX";

            return user;
        }

        public static Client GenerateClient()
        {
            Client client = new Client();
            client.Name = "Laura Hernandez";
            client.PhoneNumber = "+52 1 55782654";
            client.Email = "lhernandez@personal.com";
            client.Address = "Paseo de la Reforma, Juárez, 06600 Cuauhtémoc, CDMX";
            client.ClientId = Guid.NewGuid().ToString().Substring(0, 6);
            client.ClientStatus = ClientStatus.Ok;

            return client;
        }
    }
}
