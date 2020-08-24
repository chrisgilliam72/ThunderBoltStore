using Microsoft.AspNetCore.Mvc;
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
        [Remote(action: "VerifyEmailExists", controller: "Home")]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }
    }
}
