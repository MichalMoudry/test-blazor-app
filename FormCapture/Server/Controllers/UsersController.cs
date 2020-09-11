using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FormCapture.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FormCapture.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IConfiguration _configuration;

        private readonly SignInManager<IdentityUser> _signInManager;

        public UsersController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel registration)
        {
            if (registration == null)
            {
                return BadRequest();
            }
            IdentityUser user = new IdentityUser() { Email = registration.Email, UserName = registration.Email };
            IdentityResult res = await _userManager.CreateAsync(user, registration.Password);
            if (res.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(res.Errors);
            }
        }

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
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, login.Email)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            JwtSecurityToken token = new JwtSecurityToken(_configuration["Issuer"], _configuration["Audience"], claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}