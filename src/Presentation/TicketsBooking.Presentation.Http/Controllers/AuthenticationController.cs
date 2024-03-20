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
        JwtTokenDto jwtTokenDto = authService.RegisterUser(userCredentials);
        return jwtTokenDto;
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
            switch (e)
            {
                case WrongPasswordException:
                    return new ForbidResult();
                case UserNotFoundException:
                    return new NotFoundResult();
            }
        }

        return new BadRequestResult();
    }
}