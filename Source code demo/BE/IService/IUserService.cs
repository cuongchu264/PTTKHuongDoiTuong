using Microsoft.AspNetCore.Mvc;
using SneakerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.IService
{
    public interface IUserService
    {
        Task<ActionResult<User>> Signup(User user);
        UserLoginModel Login(UserLoginModel model);
        List<User> GetAllUsers();
    }
}
