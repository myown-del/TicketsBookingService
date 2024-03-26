using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Services;

public interface IShowService
{
    public void CreateShow(int id, string? title, string? genre, string? director, string? duration, ShowType type);

    public void DeleteShow(int showId);

    public Collection<Show> GetAllShows(ShowType showType);
}