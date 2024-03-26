using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Services;

public interface ISessionService
{
    public void CreateSession(long id, long showId, long hallId, DateTime sessionDate);

    public void DeleteSession(int sessionId);

    public Collection<Session> GetAllSessions(int showId, int venueId, DateTime fromDate, DateTime toDate);

    public Session? GetSession(int sessionId);
}