namespace TicketsBooking.Application.Models.Entities;

public class Ticket
{
    public long Id { get; set; }
    public Seat? Seat { get; set; }
    public Session? Session { get; set; }
    public User? User { get; set; }
}