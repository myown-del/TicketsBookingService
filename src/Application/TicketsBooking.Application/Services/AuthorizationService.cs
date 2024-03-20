using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Helpers;
using TicketsBooking.Application.Models.Dto;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IUserRepository _userRepository;

    public AuthorizationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public JwtTokenDto RegisterUser(UserRegister userRegister)
    {
        var passwordHash = AuthorizationHelper.CalculatePasswordHash(userRegister.Password);
        var user = new User(phoneNumber: userRegister.PhoneNumber, passwordHash: passwordHash);

        _userRepository.Add(user);
        var createdUser = _userRepository.GetByPhoneNumber(user.PhoneNumber);

        return new JwtTokenDto(
            "1", "2", 1);
    }

    public JwtTokenDto AuthorizeUser(string phoneNumber, string password)
    {
        throw new NotImplementedException();
    }

    public JwtTokenDto RefreshToken(string refreshToken)
    {
        throw new NotImplementedException();
    }
}