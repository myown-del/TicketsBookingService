namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IDeleteHall
{
    public void DeleteHall(int hallID, int venueID);
}