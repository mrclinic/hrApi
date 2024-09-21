using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace hiastHRApi.Services.Common.Token
{
    public class UserToken
    {
        public static string GenTokenkey(JwtSettings jwtSettings)
        {
            try
            {
                // Get secret key
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
                Guid Id = Guid.Empty;
                DateTime expireTime = DateTime.UtcNow.AddDays(1);
                var JWToken = new JwtSecurityToken(issuer: jwtSettings.ValidIssuer, audience: jwtSettings.ValidAudience,
                    claims: null, notBefore: new DateTimeOffset(DateTime.Now).DateTime, expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));
                return new JwtSecurityTokenHandler().WriteToken(JWToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
