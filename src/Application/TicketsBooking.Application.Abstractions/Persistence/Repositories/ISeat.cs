using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface ISeat
{
    public void DeleteSeat(int venueId, int hallId, int seatId);

    public void CreateSeat(int venueId, int hallId, int row, int number);

    public List<Seat> GetAllSeats(int venueId, int hallId);
}