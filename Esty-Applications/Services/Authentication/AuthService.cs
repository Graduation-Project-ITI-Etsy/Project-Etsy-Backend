using Esty_Models;
using Etsy_DTO.Account;
using Etsy_DTO.LoginRequest;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
         private readonly IConfiguration _configuration;

        public AuthService(UserManager<Customer> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            
               var user = await _userManager.FindByIdAsync(model.UserId);
                if (user is null )
                    return "Invalid user ID ";
                                  
                user = await _userManager.FindByIdAsync(model.UserId);
                if ( !await _roleManager.RoleExistsAsync(model.Role))
                    return "Invalid user  Role";
            
                     if (await _userManager.IsInRoleAsync(user, model.Role))
                    return "User already assigned to this role";
            
            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Sonething went wrong";
        }

        public async Task<AuthModel> GetTokenAsync(LoginDto model)
        {
            var authModel = new AuthModel();
            var user=new Customer();
            try
            {
                user = await _userManager.FindByEmailAsync(model.Email);

                if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    authModel.Message = "Email or Password is incorrect!";
                    return authModel;
                }
            } catch 
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var data = new UserDto
            {
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Image = user.Image,

            };
            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.customer = data;
            // authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();
            return authModel;
        }


        public async Task<AuthModel> RegisterAsync(Register model)
        {
            try
            {
                var existingUserByEmail = await _userManager.FindByEmailAsync(model.Email);
                if (existingUserByEmail != null)
                {
                    return new AuthModel { Message = "Email is already registered!" };
                }
                var existingUserByUsername = await _userManager.FindByNameAsync(model.Username);
                if (existingUserByUsername != null)
                {
                    return new AuthModel { Message = "Username is already registered!" };
                }
            }
            catch (Exception ex)
            {
                return new AuthModel { Message = "An error occurred during registration." };
            }
            var user = new Customer
            {
                EmailConfirmed = true,
                LockoutEnabled = false,
                UserName = model.Username,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                    errors += $"{error.Description},";
                return new AuthModel { Message = errors, IsAuthenticated = false };
            }
            var roleName = "ClassicUser";
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var newRole = new IdentityRole(roleName);
                var createRoleResult = await _roleManager.CreateAsync(newRole);
                if (!createRoleResult.Succeeded)
                {
                    return new AuthModel { Message = "Failed to create user role." };
                }
            }
            // Add the "User" role to the user
            await _userManager.AddToRoleAsync(user, roleName);
            var userRoles = await _userManager.GetRolesAsync(user);
            var jwtSecurityToken = await CreateJwtToken(user);
            return new AuthModel
            {
                Email = user.Email,
                //ExpiresOn = jwtSecurityToken.ValidTo,
                customer = new UserDto { Email = user.Email, Address = user.Address, PhoneNumber = user.PhoneNumber, Image = user.Image, UserName = user.UserName },
                IsAuthenticated = true,
                Roles = userRoles.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),

            };
        }


        private async Task<JwtSecurityToken> CreateJwtToken(Customer user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("Sid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
