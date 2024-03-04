using TicketsBooking.Application.Models.Dto;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IUserService
{
    public JwtTokenDto RegisterUser(string phoneNumber, string password, string? name = null, string? email = null, DateTime? birthdayDate = null);

    public JwtTokenDto AuthorizeUser(string phoneNumber, string password);

    public JwtTokenDto RefreshToken(string refreshToken);
}