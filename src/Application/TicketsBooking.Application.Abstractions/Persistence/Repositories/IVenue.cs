namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IVenue
{
    public void Create(string type, string name, string address);

    public void DeleteVenue(int venueId);

    public Dictionary<string, string> GetAllVenues(string type);
}