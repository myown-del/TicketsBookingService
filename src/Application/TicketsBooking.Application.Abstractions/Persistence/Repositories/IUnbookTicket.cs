namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IUnbookTicket
{
    public void BookTicket(int showID, int sessionID, int seatID);
}