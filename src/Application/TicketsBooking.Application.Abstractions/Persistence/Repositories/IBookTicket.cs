namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IBookTicket
{
    public int BookTicket(int showID, int sessionID, int seatID);
}