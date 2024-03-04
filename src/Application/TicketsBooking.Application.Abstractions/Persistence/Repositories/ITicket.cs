using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface ITicket
{
    public int BookTicket(string sessionId, int seatId);

    public void UnBookTicket(int sessionId, int seatId);

    public List<Ticket> GetAllTickets(int showId, int sessionId, bool onlyAvailable);
}