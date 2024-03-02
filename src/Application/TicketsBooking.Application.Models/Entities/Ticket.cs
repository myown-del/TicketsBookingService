namespace TicketsBooking.Application.Models.Entities;

public class Ticket
{
    public long Id { get; set; }

    public long SeatId { get; set; }

    public long SessionId { get; set; }

    public long UserId { get; set; }
}