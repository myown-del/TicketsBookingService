using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Services;

public interface ISeatService
{
    public void DeleteSeat(int seatId);

    public void CreateSeat(Seat seat);

    public Seat? GetSeat(int seatId);

    public Collection<Seat> GetAllSeats(int hallId);
}