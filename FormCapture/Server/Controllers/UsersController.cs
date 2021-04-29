using FormCapture.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FormCapture.Server.Controllers
{
    /// <summary>
    /// Controller class for handling operations with users.
    /// 
    /// Sources:
    /// SAINTY, Chris, 2019. Authentication with client-side Blazor using WebAPI and ASP.NET Core Identity. Chris Sainty [online]. [vid. 2021-04-29]. Dostupné z: https://chrissainty.com/securing-your-blazor-apps-authentication-with-clientside-blazor-using-webapi-aspnet-core-identity/
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Method for signing in a user based on entered credentials.
        /// </summary>
        /// <param name="login">User credentials in LoginModel class form.</param>
        /// <returns>400 status code or 200 with JwtSecurityToken.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            if (login == null)
            {
                return BadRequest();
            }
            Microsoft.AspNetCore.Identity.SignInResult res = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.KeepMeSignedIn, false);
            if (!res.Succeeded)
            {
                return BadRequest();
            }

            IdentityUser usr = await _userManager.FindByEmailAsync(login.Email);
            IList<string> roles = await _userManager.GetRolesAsync(usr);
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, login.Email),
                new Claim(ClaimTypes.Name, login.Email)
            };
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            JwtSecurityToken token = new JwtSecurityToken(_configuration["Issuer"], _configuration["Audience"], claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        /// <summary>
        /// Method for creaing a new user account in the system.
        /// </summary>
        /// <param name="registration">User credentials in RegistrationModel class form.</param>
        /// <returns>200 status code or 400 with specific errors.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel registration)
        {
            if (registration == null || string.IsNullOrEmpty(registration.Password) || string.IsNullOrEmpty(registration.Email) || string.IsNullOrEmpty(registration.ConfirmationPassword))
            {
                return BadRequest();
            }
            IdentityUser user = new IdentityUser() { Email = registration.Email, UserName = registration.Email };
            IdentityResult res = await _userManager.CreateAsync(user, registration.Password);
            if (res.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, registration.Role);
                return Ok();
            }
            else
            {
                return BadRequest(res.Errors);
            }
        }

        /// <summary>
        /// Method for updating user's password.
        /// </summary>
        /// <param name="profileModel">New password and email as ProfileModel instance.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPut("newpassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] ProfileModel profileModel)
        {
            if (profileModel == null)
            {
                return BadRequest();
            }
            IdentityUser usr = await _userManager.FindByEmailAsync(profileModel.Email);
            if (usr == null)
            {
                return BadRequest("No user was found.");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(usr);
            var res = await _userManager.ResetPasswordAsync(usr, token, profileModel.NewPassword);
            if (res.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}