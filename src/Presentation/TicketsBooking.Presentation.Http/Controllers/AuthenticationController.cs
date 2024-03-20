using Microsoft.AspNetCore.Mvc;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Dto;

namespace TicketsBooking.Presentation.Http.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController(IAuthenticationService authService)
{
    [HttpPost("register")]
    public ActionResult<JwtTokenDto> RegisterUser([FromBody] UserRegister userRegister)
    {
        JwtTokenDto jwtTokenDto = authService.RegisterUser(userRegister);
        return jwtTokenDto;
    }
}