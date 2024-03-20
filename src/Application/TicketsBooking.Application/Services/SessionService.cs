using System;
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

    public void CreateSession(Session session)
    {
        _sessionRepository.Add(session);
    }

    public void DeleteSession(int sessionId)
    {
        _sessionRepository.RemoveById(sessionId);
    }

    public Session? GetSession(int sessionId)
    {
        _sessionRepository.GetById(sessionId);
    }

    public Collection<Session> GetAllSessions(int showId, int venueId, DateTime fromDate, DateTime toDate)
    {
        return _sessionRepository.GetAllByParametrs(showId, venueId, fromDate, toDate);
    }
}