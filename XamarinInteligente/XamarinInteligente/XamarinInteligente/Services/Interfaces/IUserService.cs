﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinInteligente.Model.Entities;

namespace XamarinInteligente.Services.Interfaces
{
    public interface IUserService
    {
        Task<LoginStatus> Login(User user);
        Task<bool> Logout(User user);
        Task<User> GetUserInfo(User User);
    }
}
