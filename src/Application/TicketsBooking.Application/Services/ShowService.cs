using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Services;

public class ShowService : IShowService
{
    private readonly IShowRepository _showRepository;

    public ShowService(IShowRepository showRepository)
    {
        _showRepository = showRepository;
    }

    public void CreateShow(Show show)
    {
        _showRepository.CreateShow(show);
    }

    public void DeleteShow(int showId)
    {
        _showRepository.DeleteShow(showId);
    }
    
    public Collection<Show> GetAllShows(ShowType showType)
    {
        return _showRepository.GetAllShows(showType);
    }
}