using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinInteligente.Services.Requests
{

    class CreateUserRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public CreateUserRequest(string email, string address, string password, string name, string phoneNumber)
        {
            this.Address = address;
            this.Password = this.ConfirmPassword = password;
            this.PhoneNumber = phoneNumber;
            this.Name = name;
            this.Email = email;
        }
    }
}
