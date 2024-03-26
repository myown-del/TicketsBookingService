using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Services;

public class VenueService : IVenueService
{
    private readonly IVenueRepository _venueRepository;

    public VenueService(IVenueRepository venueRepository)
    {
        _venueRepository = venueRepository;
    }

    public Venue? GetVenue(int venueId)
    {
        return _venueRepository.GetById(venueId);
    }

    public void CreateVenue(long id, string name, string address, VenueType type, string city)
    {
        var venue = new Venue(id: id, name: name, address: address, type: type, city: city);
        _venueRepository.Add(venue);
    }

    public void DeleteVenue(int venueId)
    {
        _venueRepository.RemoveById(venueId);
    }

    public Collection<Venue> GetAllVenues(VenueType? type = null)
    {
        return _venueRepository.GetAll(type);
    }
}