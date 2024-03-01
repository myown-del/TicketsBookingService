namespace TicketsBooking.Application.Models.Entities;

public class Hall
{
    public long Id { get; set; }

    public long VenueId { get; set; }

    public string? HallNumber { get; set; }
}