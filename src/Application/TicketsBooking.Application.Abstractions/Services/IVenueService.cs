using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Services;

public interface IVenueService
{
    public void CreateVenue(long id, string name, string address, VenueType type, string city);

    public void DeleteVenue(int venueId);

    public Venue? GetVenue(int venueId);

    public Collection<Venue> GetAllVenues(VenueType? type = null);
}