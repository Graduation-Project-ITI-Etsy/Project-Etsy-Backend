using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.Account
{
    public  class Register
    {
       
        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(128),EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(256)]
        public string Password { get; set; }
    }
}
