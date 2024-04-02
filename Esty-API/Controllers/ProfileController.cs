using Esty_Models;
using Etsy_DTO.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Esty_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<Customer> _userManager;

        public ProfileController(UserManager<Customer> userManager)
        {
            _userManager = userManager;
        }

        //[HttpPut("Edit")]
        //public async Task<IActionResult> Edit([FromBody] UserDto userDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        //    if (userId == null)
        //    {
        //        return Unauthorized(); // Token doesn't contain user ID
        //    }

        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //    {
        //        return NotFound(); // User not found in database
        //    }

        //    // Update user properties with data from userDto
        //    user.Image = userDto.Image;
        //    user.UserName = userDto.UserName;
        //    user.Email = userDto.Email;
        //    user.Address = userDto.Address;
        //    user.PhoneNumber = userDto.PhoneNumber;

        //    var result = await _userManager.UpdateAsync(user);
        //    if (result.Succeeded)
        //    {
        //        return Ok("Profile updated successfully");
        //    }
        //    else
        //    {
        //        return BadRequest(result.Errors);
        //    }
        //}


        #region edit 
        [HttpPut("Edit")]
        public async Task<IActionResult>  Edit([FromBody]  UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var userId = HttpContext.User.Claims.FirstOrDefault(c=>c.Type== "Sid").Value;


            var user = await _userManager.FindByIdAsync(userId);
                  if (user == null)
                  {
                      return NotFound(); // User not found in database
                   }

                  //Update user properties with data from userDto
                  user.Image = userDto.Image;
                  user.UserName = userDto.UserName;
                  user.Email = userDto.Email;
                  user.Address = userDto.Address;
                  user.PhoneNumber = userDto.PhoneNumber;

                  var result = await _userManager.UpdateAsync(user);
                   if (result.Succeeded)
                   {
                       return Ok("Profile updated successfully");
                  }
                  else
                  {
                             return BadRequest(result.Errors);
                }
               
        }
        #endregion


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized(); // Token doesn't contain user ID
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound(); // User not found in database
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok("Account deleted successfully");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
