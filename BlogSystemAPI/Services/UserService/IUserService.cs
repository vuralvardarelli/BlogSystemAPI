using BlogSystemAPI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Services.UserService
{
    /// <summary>
    /// IUserService interface for auth ops
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Authenticate method to get user with Token
        /// </summary>
        /// <param name="kullaniciAdi"></param>
        /// <param name="sifre"></param>
        /// <returns></returns>
        User Authenticate(string kullaniciAdi, string sifre);
    }
}
