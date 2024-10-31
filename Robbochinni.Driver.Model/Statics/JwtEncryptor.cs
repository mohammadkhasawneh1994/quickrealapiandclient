using Microsoft.IdentityModel.Tokens;
using Robbochinni.Driver.Mag.Output;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Robbochinni.Driver.Mag.Statics
{
    public static class JwtEncryptor
    {
        private const string _issuer = "tam_issuer", _key = "ZSao5B7OVmkLdIQZxjROgaXZY9cbQHGz";
        public static string Encode(this UserInfo user)
        {
            var issuer = _issuer;
            var audience = _issuer;
            var key = Encoding.ASCII.GetBytes(_key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id!),
                new Claim(ClaimTypes.GivenName, user.FullName!),
                new Claim(ClaimTypes.Role, user.Role!),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
