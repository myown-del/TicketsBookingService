using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IShowService
{
    public void CreateShow(string title, string genre, string director, string duration, string type);

    public void DeleteShow(int showId);

    public List<Show> GetAllShows(int venueId, string showType);
}