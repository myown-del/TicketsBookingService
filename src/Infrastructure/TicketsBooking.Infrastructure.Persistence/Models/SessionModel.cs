// unset

namespace TicketsBooking.Infrastructure.Persistence.Models;

public class SessionModel
{
    public SessionModel(long id, long showId, long hallId, DateTime date)
    {
        Id = id;
        ShowId = showId;
        HallId = hallId;
        Date = date;
    }

    [Column("id")]
    public long Id { get; set; }

    [Column("show")]
    public long ShowId { get; set; }

    [Column("ad")]
    public long HallId { get; set; }

    [Column("date")]
    public DateTime Date { get; set; }
    
}