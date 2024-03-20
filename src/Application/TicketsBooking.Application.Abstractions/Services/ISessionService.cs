using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface ISessionService
{
    public void CreateSession(int showId, int hallId, DateTime someDate);

    public void DeleteSession(int sessionId);

    public Collection<Session> GetAllSessions(int showId, int venueId, DateTime fromDate, DateTime toDate);
    
    public Session? GetSession(int sessionId);
}