namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface ISession
{
    public void CreateSession(int showId, int hallId, DateTime someDate);

    public void DeleteSession(int showId, int sessionId);

    public void GetAllSessions(int showId, int venueId, DateTime fromDate, DateTime toDate);
}