using Microsoft.AspNetCore.Mvc;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Exceptions.Authentication;
using TicketsBooking.Application.Models.Dto;

namespace TicketsBooking.Presentation.Http.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController(IAuthenticationService authService)
{
    [HttpPost("register")]
    public ActionResult<JwtTokenDto> RegisterUser([FromBody] UserCredentialsDto userCredentials)
    {
        try
        {
            JwtTokenDto jwtTokenDto = authService.RegisterUser(userCredentials);
            return jwtTokenDto;
        }
        catch (Exception)
        {
            return new BadRequestResult();
        }
    }

    [HttpPost("login")]
    public ActionResult<JwtTokenDto> AuthorizeUser([FromBody] UserCredentialsDto userCredentials)
    {
        try
        {
            JwtTokenDto jwtTokenDto = authService.AuthorizeUser(userCredentials);
            return jwtTokenDto;
        }
        catch (Exception e)
        {
            return e switch
            {
                WrongPasswordException => new ForbidResult(),
                UserNotFoundException => new NotFoundResult(),
                _ => new BadRequestResult()
            };
        }
    }
    
    [HttpPost("refresh-token")]
    public ActionResult<JwtTokenDto> RefreshAccessToken([FromBody] RefreshTokenDto refreshToken)
    {
        try
        {
            JwtTokenDto jwtTokenDto = authService.RefreshAccessToken(refreshToken.RefreshToken);
            return jwtTokenDto;
        }
        catch (Exception)
        {
            return new BadRequestResult();
        }
    }
}