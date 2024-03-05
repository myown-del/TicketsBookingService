namespace TicketsBooking.Application.Models.Entities;

public class Session
{
    public long Id { get; set; }
    public Show? Show { get; set; }
    public Hall? Hall { get; set; }
    public DateTime Date { get; set; }
}