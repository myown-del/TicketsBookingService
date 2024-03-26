﻿using System.Collections.ObjectModel;
using TicketsBooking.Application.Abstractions.Persistence.Repositories;
using TicketsBooking.Application.Abstractions.Services;
using TicketsBooking.Application.Models.Dto;
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

    public Seat CreateSeat(SeatDto seatDto)
    {
        return _seatRepository.Add(seatDto);
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