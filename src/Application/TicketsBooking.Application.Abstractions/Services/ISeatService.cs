using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Services;

public interface ISeatService
{
    public void DeleteSeat(int venueId, int hallId, int seatId);

    public void CreateSeat(Seat seat);

    public Seat? GetSeat(int venueId, int hallId, int seatId);

    public Collection<Seat> GetAllSeats(int venueId, int hallId);
}