namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IHall
{
    public void CreateHall(int venueId);

    public void DeleteHall(int hallId, int venueId);

    public Dictionary<string, string> GetAllHalls(int venueNumber);
}