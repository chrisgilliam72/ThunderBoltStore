using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThunderBoltStore.ViewModels
{
    public class LoginDetails
    {
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
        // Code to compare password field
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirm password fields do not match.")]
        public string ConfirmPassword { get; set; }

        public bool IsRegistering { get; set; }

        public LoginDetails()
        {
            IsRegistering = false;
        }
    }
}
