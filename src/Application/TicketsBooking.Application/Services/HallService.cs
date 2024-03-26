using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Services;

public class HallService : IHallService
{
    private readonly IHallRepository _hallRepository;

    public HallService(IHallRepository hallRepository)
    {
        _hallRepository = hallRepository;
    }

    public Hall CreateHall(string name, long venueId)
    {
        return _hallRepository.Add(name, venueId);
    }

    public void DeleteHall(long hallId)
    {
        _hallRepository.Remove(hallId);
    }

    public Collection<Hall> GetAllHalls(long venueId)
    {
        return _hallRepository.GetAll(venueId);
    }

    public Hall? GetHall(long hallId)
    {
        return _hallRepository.GetHall(hallId);
    }
}