using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Services;

public interface ISeatService
{
    public void DeleteSeat(int venueId, int hallId, int seatId);

    public void CreateSeat(int venueId, int hallId, int row, int number);

    public Collection<Seat> GetAllSeats(int venueId, int hallId);
}