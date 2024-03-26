namespace TicketsBooking.Application.Models.Dto;

public class RefreshTokenDto
{
    public RefreshTokenDto(string refreshToken)
    {
        RefreshToken = refreshToken;
    }

    public string RefreshToken { get; set; }
}