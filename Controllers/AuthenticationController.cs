using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Ratmon.Models;

namespace Ratmon.Controllers
{
    public struct LoginData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private SignInManager<IdentityUser> SignInManager { get; set; } 
        private UserManager<IdentityUser> UserManager { get; set; }
        private JwtConfig Config { get; set; }

        public AuthenticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,IOptions<MainConfig> config)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            Config = config.Value.JWT;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginData data)
        {
            // var result = await SignInManager.PasswordSignInAsync(data.UserName, data.Password, true, false);
            var user = UserManager.Users.FirstOrDefault(x => x.UserName == data.UserName);
            var result = user != null && await UserManager.CheckPasswordAsync(user, data.Password);
            
            // var user = await UserManager.FindByNameAsync(data.UserName);
            if (result && user != null)
            {
                string[] role = [.. await UserManager.GetRolesAsync(user)];
                string token = GenerateJwtToken(role.First(), user);
                return Ok(new { token = token });
            }
            else
                return BadRequest("Your username or password is incorrect");
        }

        private string GenerateJwtToken(string role, IdentityUser user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Config.Secret));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new("sub", user.UserName ?? ""),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", user.Id),
                    new(ClaimTypes.Role, role),
                    new("LoggedOn", DateTime.Now.ToString())
                 }),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                Issuer = Config.ValidIssuer,
                Audience = Config.ValidAudience,
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(Config.ExpirationTime))
            };

            // Generate Token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
