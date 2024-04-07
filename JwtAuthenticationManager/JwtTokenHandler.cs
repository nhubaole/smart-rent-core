using JwtAuthenticationManager.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SERCURITY_KEY = "DcmKLDFQqxbFvVvcmyHUGYdXztGAUepr";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        //private readonly List<UserAccount> _users;

        public JwtTokenHandler() { }

        public AuthenticationRes? GenerateToken(AuthenticationReq req, object user)
        {
            if (string.IsNullOrWhiteSpace(req.UserName) || string.IsNullOrWhiteSpace(req.Password))
            {
                return null;
            }

            if (user == null) return null;
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.UTF8.GetBytes(JWT_SERCURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {

                new Claim(JwtRegisteredClaimNames.Name, req.UserName)

            });

            var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                    );

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationRes
            {
                UserName = req.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                AccessToken = token,
            };
        }
    }
}
