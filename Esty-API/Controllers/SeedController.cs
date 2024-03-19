using Esty_Context;
using Esty_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Esty_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
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

        [HttpGet]
        public async Task<ActionResult> CreateDefaultUsers()
        {
            // setup the default role names
            string role_RegisteredUser = "RegisteredUser";
            string role_Administrator = "Administrator";
            // create the default roles (if they don't exist yet)
            if (await _roleManager.FindByNameAsync(role_RegisteredUser) == null)
                await _roleManager.CreateAsync(new
                 IdentityRole(role_RegisteredUser));
            if (await _roleManager.FindByNameAsync(role_Administrator) == null)
                await _roleManager.CreateAsync(new
                 IdentityRole(role_Administrator));
            // create a list to track the newly added users
            var addedUserList = new List<Customer>();
            // check if the admin user already exists
            var email_Admin = "admin1@email.com";
            if (await _userManager.FindByNameAsync(email_Admin) == null)
            {
                // create a new admin ApplicationUser account
                var user_Admin = new Customer()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = email_Admin,
                    Email = email_Admin,
                    Address="Cairo1",
                    Image = "21.jpg"
                };
                // insert the admin user into the DB
                await _userManager.CreateAsync(user_Admin, _configuration["DefaultPasswords:Administrator"]);
                // assign the "RegisteredUser" and "Administrator" roles
                
                await _userManager.AddToRoleAsync(user_Admin,
                 role_Administrator);
                // confirm the e-mail and remove lockout
                user_Admin.EmailConfirmed = true;
                user_Admin.LockoutEnabled = false;
                // add the admin user to the added users list
                addedUserList.Add(user_Admin);
            }
            // check if the standard user already exists
            var email_User = "user1@email.com";
            if (await _userManager.FindByNameAsync(email_User) == null)
            {
                // create a new standard ApplicationUser account
                var user_User = new Customer()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = email_User,
                    Email = email_User,
                    Address="Qena1",
                    Image="11.jpg"
                };
                await _userManager.CreateAsync(user_User, _configuration["DefaultPasswords:Administrator"]);

                // Assign the "RegisteredUser" and "Administrator" roles
                await _userManager.AddToRoleAsync(user_User, role_RegisteredUser);
                

                // Confirm the e-mail and remove lockout
                user_User.EmailConfirmed = true;
                user_User.LockoutEnabled = false;

                // Add the admin user to the added users list
                addedUserList.Add(user_User);

            }

            return Ok("success");
        }

        
    } 
}    
