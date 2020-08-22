using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThunderBoltStoreMVC.ViewModels
{
    public class RegistrationDetails
    {
        [Required]
        [Remote(action:"VerifyEmail", controller:"Home")]
        public String Email { get; set; }

        public String Password { get; set; }
    }
}
