using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Format for Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
