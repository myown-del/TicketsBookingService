namespace TicketsBooking.Application.Models.Entities;

public class Venue
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public VenueType Type { get; set; }
}