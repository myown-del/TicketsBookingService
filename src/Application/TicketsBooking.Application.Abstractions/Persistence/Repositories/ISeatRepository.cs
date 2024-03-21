using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface ISeatRepository
{
    public Collection<Seat> GetAll(int hallId);

    public Seat? GetSeat(int seatId);

    public void Add(Seat seat);

    public void Remove(int seatId);
}