using Microsoft.AspNetCore.Mvc;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Presentation.Http.Controllers;

[ApiController]
[Route("api/session")]
public class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpDelete("{sessionId}")]
    public ActionResult DeleteSession(int sessionId)
    {
        Session? session = _sessionService.GetSession(sessionId);

        if (session is null)
            return new NotFoundResult();

        _sessionService.DeleteSession(sessionId);
        return new OkResult();
    }

    [HttpPost("{venueId}/halls")]
    public ActionResult CreateSession(int showId, int hallId, DateTime someDate)
    {
        _sessionService.CreateSession(showId, hallId, someDate);
        return new OkResult();
    }
}