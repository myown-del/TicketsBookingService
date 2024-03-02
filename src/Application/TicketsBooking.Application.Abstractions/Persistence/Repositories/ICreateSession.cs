namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface ICreateSession
{
    public void CreateShow(int showID, int hallID, DateTime someDate);
}