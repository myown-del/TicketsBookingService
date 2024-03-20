using TicketsBooking.Application.Models.Dto;

namespace TicketsBooking.Application.Abstractions.Services;

public interface IAuthenticationService
{
    public JwtTokenDto RegisterUser(UserCredentialsDto userCredentials);

    public JwtTokenDto AuthorizeUser(UserCredentialsDto userCredentials);

    public JwtTokenDto RefreshToken(string accessToken, string refreshToken);
}