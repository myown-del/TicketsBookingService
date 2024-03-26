using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Exceptions.Authentication;
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

    public JwtTokenDto RegisterUser(UserCredentialsDto userCredentials)
    {
        string passwordHash = AuthenticationHelper.CalculatePasswordHash(userCredentials.Password);
        JwtTokenDto jwtToken = AuthenticationHelper.GenerateJwtToken(userCredentials.PhoneNumber);

        var user = new User(
            phoneNumber: userCredentials.PhoneNumber,
            passwordHash: passwordHash,
            refreshToken: jwtToken.RefreshToken,
            refreshTokenExpiresAt: AuthenticationHelper.GetRefreshTokenExpiryDate());

        _userRepository.Add(user);
        User? createdUser = _userRepository.GetByPhoneNumber(user.PhoneNumber);

        return jwtToken;
    }

    public JwtTokenDto AuthorizeUser(UserCredentialsDto userCredentials)
    {
        string passwordHash = AuthenticationHelper.CalculatePasswordHash(userCredentials.Password);

        User? user = _userRepository.GetByPhoneNumber(userCredentials.PhoneNumber);
        if (user is null)
        {
            throw new UserNotFoundException();
        }

        if (user.PasswordHash != passwordHash)
        {
            throw new WrongPasswordException();
        }

        JwtTokenDto jwtToken = AuthenticationHelper.GenerateJwtToken(
            phoneNumber: userCredentials.PhoneNumber,
            refreshToken: user.RefreshToken);
        return jwtToken;
    }

    public JwtTokenDto RefreshAccessToken(string refreshToken)
    {
        User? user = _userRepository.GetByRefreshToken(refreshToken);
        if (user is null)
        {
            throw new UserNotFoundException();
        }

        JwtTokenDto jwtToken = AuthenticationHelper.GenerateJwtToken(
            phoneNumber: user.PhoneNumber,
            refreshToken: user.RefreshToken);
        return jwtToken;
    }
}