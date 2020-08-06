using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinInteligente.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> CreateUser(string email, string address, string password, string name, string phoneNumber);
    }
}
