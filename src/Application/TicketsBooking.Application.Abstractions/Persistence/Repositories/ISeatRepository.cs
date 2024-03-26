using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Dto;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface ISeatRepository
{
    public Collection<Seat> GetAll(int hallId);

    public Seat? GetSeat(int seatId);

    public Seat Add(SeatDto seatDto);

    public void Remove(int seatId);
}