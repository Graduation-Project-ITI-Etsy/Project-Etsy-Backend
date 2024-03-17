using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.LoginRequest
{
    public  class LoginDto
    {
        [Required(ErrorMessage = "Email is required.")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public required string Password { get; set; }
    }
}
