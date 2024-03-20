namespace TicketsBooking.Application.Models.Entities;

public class Session
{
    public Session(long id, long showId, long hallId, DateTime date)
    {
        Id = id;
        ShowId = showId;
        HallId = hallId;
        Date = date;
    }

    public long Id { get; set; }

    public long ShowId { get; set; }

    public long HallId { get; set; }

    public DateTime Date { get; set; }
}