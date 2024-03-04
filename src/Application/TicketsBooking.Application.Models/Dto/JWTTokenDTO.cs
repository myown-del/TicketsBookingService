namespace TicketsBooking.Application.Models.Dto;

public class JwtTokenDto
{
    public string? RefreshToken{ get; set; }
    public string? AccessToken{ get; set; }
    public int ExpiresIn{ get; set; }
    public string? TokenType{ get; set; }
}