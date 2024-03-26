using Microsoft.AspNetCore.Mvc;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Entities;
using TicketsBooking.Infrastructure.Persistence.Exceptions;
using TicketsBooking.Presentation.Http.Models.Sessions;


namespace TicketsBooking.Presentation.Http.Controllers;

[ApiController]
[Route("api/sessions")]
public class SessionController(ISessionService sessionService)
{
    [HttpDelete("{id}")]
    public ActionResult DeleteSession(int sessionId)
    {
        try
        {
            sessionService.GetSession(sessionId);
        }
        catch (Exception exception)
        {
            if (exception is NotFoundException)
            {
                return new NotFoundResult();
            }
            return new BadRequestResult();
        }
        return new OkResult();
    }

    [HttpGet("{id}")]
    public ActionResult<SessionDto> GetSession(int sessionId)
    {
        Session? session = sessionService.GetSession(sessionId);
        
        if (session is not null)
            return new SessionDto(session.Id, session.ShowId, session.HallId, session.Date);
        
        return new NotFoundResult();
    }

    [HttpGet("")]
    public IEnumerable<SessionDto> GetAllSessions(int showId, int venueId, DateTime fromDate, DateTime toDate)
    {
        IEnumerable<Session> sessions = sessionService.GetAllSessions(showId, venueId, fromDate, toDate);
        var response = new List<SessionDto>();
        foreach (Session session in sessions)
        {
            response.Add(new SessionDto(session.Id, session.ShowId, session.HallId, session.Date));
        }
        return response;
    }

    [HttpPost("")]
    public ActionResult CreateSession([FromBody] Session session)
    {
        sessionService.CreateSession(session.Id, session.ShowId, session.HallId, session.Date);
        return new OkResult();
    }
}