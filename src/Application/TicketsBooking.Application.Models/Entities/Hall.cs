namespace TicketsBooking.Application.Models.Entities;

public class Hall
{
    public Hall(long id, long venueId, string name)
    {
        Id = id;
        VenueId = venueId;
        Name = name;
    }

    public long Id { get; set; }

    public long VenueId { get; set; }

    public string Name { get; set; }
}