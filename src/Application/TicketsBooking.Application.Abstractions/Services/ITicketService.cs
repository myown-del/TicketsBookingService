using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Services;

public interface ITicketService
{
    public int BookTicket(int sessionId, int seatId);

    public void UnBookTicket(int sessionId, int seatId);

    public Collection<Ticket> GetAllTickets(int showId, int sessionId, bool onlyAvailable);
}