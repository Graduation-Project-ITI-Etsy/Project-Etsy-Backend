using Esty_Applications.Services.Login;
using Esty_Context;
using Esty_Models;
using Etsy_DTO.LoginRequest;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Esty_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly EtsyDbContext _context;
        private readonly UserManager<Customer> _userManager;
        private readonly JwtHandler _jwtHandler;
        public AccountController(
            EtsyDbContext context,
            UserManager<Customer> userManager,
            JwtHandler jwtHandler)
        {
            _context = context;
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Email);
            if (user == null
                || !await _userManager.CheckPasswordAsync(user, loginRequest.Password))
                return Unauthorized(new LoginResult()
                {
                    Success = false,
                    Message = "Invalid Email or Password."
                });
            var secToken = await _jwtHandler.GetTokenAsync(user);
            var jwt = new JwtSecurityTokenHandler().WriteToken(secToken);
            return Ok(new LoginResult()
            {
                Success = true,
                Message = "Login successful",
                Token = jwt
            });
        }
    }
}
