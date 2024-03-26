namespace TicketsBooking.Application.Models.Entities;

public class Venue
{
    public Venue(long id, string name, string address, VenueType type, string city)
    {
        Id = id;
        Name = name;
        Address = address;
        Type = type;
        City = city;
    }

    public long Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public VenueType Type { get; set; }

    public string City { get; set; }
}