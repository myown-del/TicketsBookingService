using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Services;

public interface IVenueService
{
    public void CreateVenue(Venue venue);

    public void DeleteVenue(int venueId);

    public Venue? GetVenue(int venueId);

    public Collection<Venue> GetAllVenues(string? type = null);
}