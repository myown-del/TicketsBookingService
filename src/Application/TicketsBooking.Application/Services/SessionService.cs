﻿using System.Collections.ObjectModel;
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

    public void CreateSession(long id, long showId, long hallId, DateTime sessionDate)
    {
        var session = new Session(id: id, showId: showId, hallId: hallId, date: sessionDate);
        _sessionRepository.Add(session);
    }

    public void DeleteSession(int sessionId)
    {
        _sessionRepository.RemoveById(sessionId);
    }

    public Session? GetSession(int sessionId)
    {
        return _sessionRepository.GetById(sessionId);
    }

    public Collection<Session> GetAllSessions(int showId, int venueId, DateTime fromDate, DateTime toDate)
    {
        return _sessionRepository.GetAllByParametrs(showId, venueId, fromDate, toDate);
    }
}