namespace TicketsBooking.Application.Models.Entities;

public class Hall
{
    public long Id { get; set; }

    public Venue? Venue { get; set; }

    public string? HallNumber { get; set; }
}