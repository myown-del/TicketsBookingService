using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsBooking.Infrastructure.Persistence.Models;

public class HallModel
{
    public HallModel(long id, string name, long venueId)
    {
        Id = id;
        Name = name;
        VenueId = venueId;
    }

    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("venue_id")]
    public long VenueId { get; set; }
}