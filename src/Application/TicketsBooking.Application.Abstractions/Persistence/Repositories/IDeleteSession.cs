namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IDeleteSession
{
    public void DeleteSeat(int showID, int sessionID);
}