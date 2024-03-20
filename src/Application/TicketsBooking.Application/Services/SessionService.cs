using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Services;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _sessionRepository;

    public SessionService(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public void CreateSession(int showId, int hallId, DateTime someDate)
    {
        // _sessionRepository.Add(showId, hallId, someDate);
        throw new NotImplementedException();
    }

    public void DeleteSession(int sessionId)
    {
        throw new NotImplementedException();
    }

    public void DeleteSession(int showId, int sessionId)
    {
        // _sessionRepository.RemoveById(showId, sessionId);
        throw new NotImplementedException();
    }

    public Session GetSession(int sessionId)
    {
        // return _sessionRepository.GetById(sessionId);
        throw new NotImplementedException();
    }

    public Collection<Session> GetAllSessions(int showId, int venueId, DateTime fromDate, DateTime toDate)
    {
        return _sessionRepository.GetAllByParametrs(showId, venueId, fromDate, toDate);
    }
}
