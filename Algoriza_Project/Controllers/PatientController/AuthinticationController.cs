using Algoriza_Project.Areas.Identity.Pages.Account;
using Core.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Algoriza_Project.Controllers.PatientController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthinticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthinticationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel.InputModel model)
        {
            if (ModelState.IsValid)
            {
                User patient = new ()
                {
                    UserType = "Patient",
                    UserName = model.Username,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Gender = (Gender)Enum.Parse(typeof(Gender), model.Gender),
                    DateOfBirth = model.BirthDate
                };

                var result = await _userManager.CreateAsync(patient, model.Password);
                await _userManager.AddToRoleAsync(patient, "Patient");
                if (result.Succeeded)
                {
                    return Ok("User registered successfully");
                }


                return BadRequest(result.Errors);
            }

            return BadRequest(new { Message = "Invalid registration model" });
        }



        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginModel.InputModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return Ok("User Login successfully");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return BadRequest(new { Message = "Invalid Login model" });
        }

    }
}

