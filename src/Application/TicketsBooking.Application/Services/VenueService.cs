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

    public void CreateVenue(Venue venue)
    {
        _venueRepository.Add(venue);
    }

    public void DeleteVenue(int venueId)
    {
        throw new NotImplementedException();
    }

    public Collection<Venue> GetAllVenues(string? type = null)
    {
        return _venueRepository.GetAll();
    }
}