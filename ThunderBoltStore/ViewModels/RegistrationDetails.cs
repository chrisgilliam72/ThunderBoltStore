using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThunderBoltStore.ViewModels
{
    public class RegistrationDetails
    {
        [Required]
        [Remote(action: "VerifyEmailDoesntExist", controller: "Home")]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        [Remote(action: "VerifyPasswordValid", controller: "Home")]
        public String Password { get; set; }

        // Code to compare password field
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirm password fields do not match.")]
        public string ConfirmPassword { get; set; }

        public bool IsRegistering { get; set; }

        public List<String> RegistrationErrors { get; set; }

        public RegistrationDetails()
        {
            IsRegistering = false;
            RegistrationErrors = new List<string>();
        }
    }
}
