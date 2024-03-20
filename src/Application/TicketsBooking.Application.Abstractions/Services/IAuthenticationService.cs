﻿using TicketsBooking.Application.Models.Dto;

namespace TicketsBooking.Application.Abstractions.Services;

public interface IAuthenticationService
{
    public JwtTokenDto RegisterUser(UserRegister userRegister);

    public JwtTokenDto AuthorizeUser(string phoneNumber, string password);

    public JwtTokenDto RefreshToken(string refreshToken);
}