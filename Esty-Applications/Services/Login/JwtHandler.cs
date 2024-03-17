using Esty_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Services.Login
{
    public  class JwtHandler
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Customer> _userManager;
        public JwtHandler(
            IConfiguration configuration,
            UserManager<Customer> userManager
 )
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        public async Task<JwtSecurityToken> GetTokenAsync(Customer user)
        {
            var jwt = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: await GetClaimsAsync(user),
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(
                    _configuration["JwtSettings:ExpirationTimeInMinutes"])),
                signingCredentials: GetSigningCredentials());
            return jwt;
        }
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(
                _configuration["JwtSettings:SecurityKey"]!);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret,
                SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaimsAsync(Customer user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email!)
            };
            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

    }
}
