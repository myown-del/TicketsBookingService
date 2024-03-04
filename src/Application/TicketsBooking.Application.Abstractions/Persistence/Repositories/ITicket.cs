namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface ITicket
{
    public int BookTicket(int sessionId, int seatId);

    public void UnBookTicket(int sessionId, int seatId);

    public Dictionary<string, object> GetAllTickets(int showId, int sessionId, bool onlyAvailable);
}