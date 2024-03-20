using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
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

    [HttpDelete("{id}")]
    public ActionResult DeleteSession(int id)
    {
        Session? session = _sessionService.GetSession(id);

        if (session is null)
            return new NotFoundResult();

        _sessionService.DeleteSession(sessionId);
        return new OkResult();
    }

    [HttpGet("{id}")]
    public ActionResult<Session> GetSession(int id)
    {
        Session? session = _sessionService.GetSession(id);

        if (session is null)
            return new NotFoundResult();
        return session;
    }

    [HttpGet("")]
    public ActionResult<Collection<Session>> GetAllSessions(int showId, int venueId, DateTime fromDate, DateTime toDate)
    {
        Collection<Session> sessions = _sessionService.GetAllSessions(showId, venueId, fromDate, toDate);
        return sessions;
    }

    [HttpPost("")]
    public ActionResult CreateSession(Session session)
    {
        _sessionService.CreateSession(session);
        return new OkResult();
    }
}