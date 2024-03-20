using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface ISeatRepository
{
    public Collection<Seat> GetAll(int venueId, int hallId);

    public Seat? GetSeat(int venueId, int hallId, int seatId);

    public void Add(Seat seat);

    public void Remove(int venueId, int hallId, int seatId);
}