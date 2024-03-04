using TicketsBooking.Application.Models.Dto;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IUser
{
    public JwtTokenDto Registration(string phoneNumber, string password, string name, string email, DateTime birthdayDate, bool isAdmin);

    public JwtTokenDto Authorisation(string phoneNumber, string password);

    public JwtTokenDto UpdatingToken(string refreshToken);
}