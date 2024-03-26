using System.ComponentModel.DataAnnotations.Schema;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Infrastructure.Persistence.Models;

public class HallModel
{
    public HallModel(long id, string name, long venueId)
    {
        Id = id;
        Name = name;
        VenueId = venueId;
    }

    public HallModel() { }

    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("venue_id")]
    public long VenueId { get; set; }

    public VenueModel? Venue { get; set; }

    public Hall MapTo()
    {
        return new Hall(id: Id, venue: Venue!.MapTo(), Name!);
    }
}