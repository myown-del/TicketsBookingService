using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Dto;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Services;

public interface ISeatService
{
    public void DeleteSeat(int seatId);

    public Seat CreateSeat(SeatDto seatDto);

    public Seat? GetSeat(int seatId);

    public Collection<Seat> GetAllSeats(int hallId);
}