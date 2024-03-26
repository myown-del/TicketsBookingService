using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IShowRepository
{
    public void CreateShow(Show show);

    public void DeleteShow(int showId);

    public Collection<Show> GetAllShows(ShowType showType);
}