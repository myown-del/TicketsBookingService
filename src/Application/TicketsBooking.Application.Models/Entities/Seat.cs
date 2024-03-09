namespace TicketsBooking.Application.Models.Entities;

public class Seat
{
    public long Id { get; set; }

    public Hall? Hall { get; set; }

    public long Number { get; set; }

    public long Row { get; set; }
}