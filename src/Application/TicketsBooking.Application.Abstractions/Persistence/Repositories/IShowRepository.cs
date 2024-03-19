using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IShowRepository
{
    public void CreateShow(string? title, string? genre, string? director, string? duration, ShowType type);

    public void DeleteShow(int showId);

    public Collection<Show> GetAllShows(int venueId, string showType);
}