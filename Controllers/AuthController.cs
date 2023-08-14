using IOTBackend.Dto;
using IOTBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IOTBackend.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public SignInManager<User> SignInManager { get; set; }
        public UserManager<User> UserManager { get; set; }

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }


        [HttpPost("signup")]
        public async Task<User> SignUp(SignUpDto signUpDto)
        {
            var user = new User
            {
                UserName = signUpDto.Username,
            };

            var result = await UserManager.CreateAsync(user, signUpDto.Password);

            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, false);
            }

            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var result = await SignInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);

            if (result.Succeeded)
            {
                return new JsonResult(new
                {
                    message = "success"
                });
            }

            return new JsonResult(new
            {
                message = "error"
            });
        }
    }
}
