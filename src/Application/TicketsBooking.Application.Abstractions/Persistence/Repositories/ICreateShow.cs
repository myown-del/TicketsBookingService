namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface ICreateShow
{
    public void CreateShow(int showID, int venueID, DateTime fromDate, DateTime toDate);
}