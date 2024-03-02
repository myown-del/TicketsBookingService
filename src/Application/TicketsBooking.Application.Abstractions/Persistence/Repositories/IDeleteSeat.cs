namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IDeleteSeat
{
    public void DeleteSeat(int venueID, int hallID, int seatID);
}