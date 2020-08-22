using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ThunderBoltStore.Models;
using ThunderBoltStore.ViewModels;

namespace ThunderBoltStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AcceptVerbs("GET")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyEmailDoesntExist([Bind(Prefix = "Email")] string emailAddress)
        {
            if (emailAddress != null)
            {              
                var usrDetails = await _userManager.FindByEmailAsync(emailAddress);
                if (usrDetails != null)
                    return Json($"Email address already registered");

                return Json(true);
            }

            return Json(true);
        }

        [AcceptVerbs("GET")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyPasswordValid([Bind(Prefix = "Password")] string password)
        {
            String errorList = "";
            var passwordValidator = new PasswordValidator<IdentityUser>();
            var result =await passwordValidator.ValidateAsync(_userManager, null, password);
            if (result!=IdentityResult.Success)
            {
                foreach (var error in result.Errors)
                    errorList += error.Description + "<br/>";
                return Json(errorList);
            }

            return Json(true);
        }

        public IActionResult Login(RegistrationDetails model)
        {
            return RedirectToAction("Orders", "Orders");
        }

        public async Task<IActionResult> Register(RegistrationDetails model)
        {
            var identityUser = new IdentityUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(identityUser, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(identityUser, "User");
                return RedirectToAction("Orders", "Orders");

            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
                model.RegistrationErrors.Add(error.Description);
            }

            return PartialView("/Views/Home/_Register.cshtml", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
