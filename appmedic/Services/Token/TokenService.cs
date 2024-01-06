using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using appmedic.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace appmedic.Services.Token;

public class TokenService
{
    public static object GenerateToken(User user)
    {
        var Key = Encoding.ASCII.GetBytes(Services.Token.Key.Secret);
        var tokenConfig = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                //new("Id", user.Id.ToString()),
                new Claim(type:ClaimTypes.Name , user.UserName),
                new Claim(type:ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddHours(3),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenConfig);
        var tokenString = tokenHandler.WriteToken(token);
        return new
        {
            token = tokenString
        };
    }
}