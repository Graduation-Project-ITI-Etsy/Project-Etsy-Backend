using Esty_Context;
using Esty_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Esty_API.Controllers
{
    public class SeedController : Controller
    {
        private readonly EtsyDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Customer> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        public SeedController(
                EtsyDbContext context,
                RoleManager<IdentityRole> roleManager,
                UserManager<Customer> userManager,
                IWebHostEnvironment env,
         IConfiguration configuration)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _env = env;
            _configuration = configuration;
        }
    }
}
