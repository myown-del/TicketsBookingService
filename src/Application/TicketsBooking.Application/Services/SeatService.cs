using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Services;

public class SeatService : ISeatService
{
    private readonly ISeatRepository _seatRepository;

    public SeatService(ISeatRepository seatRepository)
    {
        _seatRepository = seatRepository;
    }

    public void DeleteSeat(int seatId)
    {
        _seatRepository.Remove(seatId);
    }

    public void CreateSeat(Seat seat)
    {
        _seatRepository.Add(seat);
    }

    public Seat? GetSeat(int seatId)
    {
        return _seatRepository.GetSeat(seatId);
    }
    
    public Collection<Seat> GetAllSeats(int hallId)
    {
        return _seatRepository.GetAll(hallId);
    }
}