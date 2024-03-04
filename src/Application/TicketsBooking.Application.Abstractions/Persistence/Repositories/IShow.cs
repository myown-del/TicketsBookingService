namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IShow
{
    public void CreateShow(string title, string genre, string director, string duration, string type);

    public void DeleteShow(int showId);

    public Dictionary<string, object> GetAllShows(int venueId, string showType);
}