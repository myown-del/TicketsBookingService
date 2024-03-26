using System.ComponentModel.DataAnnotations.Schema;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Infrastructure.Persistence.Models;

public class VenueModel
{
    public VenueModel(long id, string name, string address, string type, string city)
    {
        Id = id;
        Name = name;
        Address = address;
        Type = type;
        City = city;
    }

    [Column("id")]
    public long Id { get; set; }

    [Column("name")]

    public string Name { get; set; }

    [Column("address")]

    public string Address { get; set; }

    [Column("type")]

    public string Type { get; set; }

    [Column("city")]

    public string City { get; set; }

    public Venue MapTo()
    {
        var type = (VenueType)Enum.Parse(typeof(VenueType), Type, true);
        return new Venue(Id, Name, Address, type, City);
    }
}