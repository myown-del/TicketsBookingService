namespace TicketsBooking.Application.Models.Dto;

public class JwtTokenDto
{
    public JwtTokenDto(string refreshToken, string accessToken, int expiresIn, string tokenType = "Bearer")
    {
        RefreshToken = refreshToken;
        AccessToken = accessToken;
        ExpiresIn = expiresIn;
        TokenType = tokenType;
    }

    public string RefreshToken { get; set; }

    public string AccessToken { get; set; }

    public int ExpiresIn { get; set; }

    public string TokenType { get; set; }
}