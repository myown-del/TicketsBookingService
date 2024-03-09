using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IVenueService
{
    public void CreateVenue(string type, string name, string address);

    public void DeleteVenue(int venueId);

    public Collection<Venue> GetAllVenues(string type);
}