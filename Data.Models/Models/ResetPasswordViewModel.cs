using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Models
{
    public class ResetPasswordViewModel
    {
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Passwrods donot match")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
