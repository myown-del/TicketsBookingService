using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IVenueService
{
    public void CreateVenue(string type, string name, string address);

    public void DeleteVenue(int venueId);

    public List<Venue> GetAllVenues(string type);
}