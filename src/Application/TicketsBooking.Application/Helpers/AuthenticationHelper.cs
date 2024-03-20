using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TicketsBooking.Application.Models.Dto;

namespace TicketsBooking.Application.Helpers;

public static class AuthenticationHelper
{
    private static string _secretKey = "SecretKey1111222233334444";

    private static int _refreshTokenExpirySeconds = 3600;

    private static int _accessTokenExpirySeconds = 3600;

    public static void SetConfig(IConfiguration configuration)
    {
        string? secretKey = configuration.GetSection("Application:Authentication:SecretKey").Value;
        if (secretKey != null)
            _secretKey = secretKey;

        string? accessTokenExpirySeconds =
            configuration.GetSection("Application:Authentication:AccessTokenExpirySeconds").Value;
        if (accessTokenExpirySeconds != null)
            _accessTokenExpirySeconds = Convert.ToInt32(accessTokenExpirySeconds);

        string? refreshTokenExpirySeconds =
            configuration.GetSection("Application:Authentication:RefreshTokenExpirySeconds").Value;

        if (refreshTokenExpirySeconds != null)
            _refreshTokenExpirySeconds = Convert.ToInt32(refreshTokenExpirySeconds);
    }

    public static DateTime GetRefreshTokenExpiryDate()
    {
        return DateTime.UtcNow.AddSeconds(_refreshTokenExpirySeconds);
    }

    public static string CalculatePasswordHash(string password)
    {
        using var md5 = MD5.Create();
        byte[] inputBytes = Encoding.ASCII.GetBytes(password);
        byte[] hashBytes = md5.ComputeHash(inputBytes);
        return Convert.ToHexString(hashBytes);
    }

    public static JwtTokenDto GenerateJwtToken(string phoneNumber, string? refreshToken = null)
    {
        refreshToken ??= Guid.NewGuid().ToString("N");

        return new JwtTokenDto(
            refreshToken,
            GenerateAccessToken(phoneNumber),
            _accessTokenExpirySeconds);
    }

    private static string GenerateAccessToken(string phoneNumber)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, phoneNumber),
        };

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddSeconds(_accessTokenExpirySeconds),
            SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken? accessToken = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(accessToken);
    }
}