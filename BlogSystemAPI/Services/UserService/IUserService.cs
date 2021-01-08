using BlogSystemAPI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Services.UserService
{
    public interface IUserService
    {
        User Authenticate(string kullaniciAdi, string sifre);
    }
}
