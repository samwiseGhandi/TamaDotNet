namespace TamaDotNet.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : Controller
    {
        readonly IConfiguration configuration;

        public IdentityController(IConfiguration configurator)
        {
            configuration = configurator;
        }

        string GenerateToken(string id)
        {
            string key = configuration.GetValue<string>("TokenKey"); ;

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
    }
}
