namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface ICreateSeats
{
    public void CreateSeats(int venueID, int hallID);
}