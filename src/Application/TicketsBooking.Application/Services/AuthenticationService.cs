using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Helpers;
using TicketsBooking.Application.Models.Dto;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public JwtTokenDto RegisterUser(UserRegister userRegister)
    {
        string passwordHash = AuthenticationHelper.CalculatePasswordHash(userRegister.Password);
        var jwtToken = AuthenticationHelper.GenerateJwtToken(userRegister.PhoneNumber);

        var user = new User(
            phoneNumber: userRegister.PhoneNumber,
            passwordHash: passwordHash,
            refreshToken: jwtToken.RefreshToken,
            refreshTokenExpiresAt: AuthenticationHelper.GetRefreshTokenExpiry());

        _userRepository.Add(user);
        User? createdUser = _userRepository.GetByPhoneNumber(user.PhoneNumber);

        return jwtToken;
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