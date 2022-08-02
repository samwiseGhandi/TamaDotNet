using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TamaDotNet.Server.Models;
using TamaDotNet.Shared.DTO;

namespace TamaDotNet.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : Controller
    {
        readonly IConfiguration _configuration;
        readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityController(IConfiguration configurator, SignInManager<ApplicationUser> signInManager)
        {
            _configuration = configurator;
            _signInManager = signInManager;

        }

        string GenerateToken(string id)
        {
            string key = _configuration.GetValue<string>("TokenKey"); ;

            // Create Security key  using private key above:
            // not that latest version of JWT using Microsoft namespace instead of System
            var securityKey = new Microsoft
                .IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            // Also note that securityKey length should be >256b
            // so you have to make sure that your private key has a proper length

            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
                              (securityKey, SecurityAlgorithms.HmacSha256Signature);


            var claims = new List<Claim>() // All claims to be added to the JWT token
            {
                new Claim(ClaimTypes.UserData, id),
            };

            JwtSecurityToken SecurityToken = new JwtSecurityToken(
                claims: claims, // Claims to be added to the Token
                signingCredentials: credentials // Credentials of the Token
                ); // Full token

            var handler = new JwtSecurityTokenHandler(); // Token reader


            return handler.WriteToken(SecurityToken);
        }

        [HttpPost("signup")]
        public async Task<ActionResult> SignUp(SignupModel signupModel) {
            if(signupModel != null) {
                ApplicationUser apUser = new ApplicationUser() {
                    UserName = signupModel.Name
                };


                var _createdUser = await _signInManager.UserManager.CreateAsync(apUser, signupModel.Password);
                
                if(_createdUser.Succeeded) {
                    apUser.Token = GenerateToken(apUser.Id);
                    await _signInManager.UserManager.UpdateAsync(apUser);
                    return Ok($"\"{apUser.Token}\"");
                    
                    
                }
            }
            return BadRequest("Try again..");
        }
        [HttpPost("login")]
        public async Task<ActionResult> LogIn(LoginModel loginModel) {
            if(loginModel != null) {
                var _dbUser = await _signInManager.UserManager.FindByNameAsync(loginModel.Name);

                if(_dbUser != null) {
                    var _loginAttempt = await _signInManager.CheckPasswordSignInAsync(_dbUser, loginModel.Password, false);
                    
                    if(_loginAttempt.Succeeded) {
                        return Ok($"\"{_dbUser.Token}\"");
                    }
                }
            }
            return BadRequest("Try again..");
        }
    }
}
