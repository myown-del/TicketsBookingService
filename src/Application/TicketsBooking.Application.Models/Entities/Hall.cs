namespace TicketsBooking.Application.Models.Entities;

public class Hall
{
    public Hall(long id, Venue venue, string name)
    {
        Id = id;
        Venue = venue;
        Name = name;
    }

    public long Id { get; set; }

    public Venue Venue { get; set; }

    public string Name { get; set; }
}