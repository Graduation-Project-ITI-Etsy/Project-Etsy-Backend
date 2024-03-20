using Etsy_DTO.Account;
using Etsy_DTO.LoginRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Services.Authentication
{
    public  interface IAuthService
    {
        Task<AuthModel> RegisterAsync(Register model);

        Task<AuthModel> GetTokenAsync(LoginDto model);

        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
