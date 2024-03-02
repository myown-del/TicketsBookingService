namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IDeleteShow
{
    public void DeleteSeat(int showID);
}