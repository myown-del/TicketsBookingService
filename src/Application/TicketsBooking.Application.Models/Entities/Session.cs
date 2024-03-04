namespace TicketsBooking.Application.Models.Entities;

public class Session
{
    public long Id { get; set; }
    public long ActId { get; set; }
    public long HallId { get; set; }
    public DateTime Date { get; set; }
}