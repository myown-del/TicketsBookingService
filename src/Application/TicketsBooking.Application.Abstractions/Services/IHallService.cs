using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Services;

public interface IHallService
{
    public void CreateHall(Hall hall);

    public void DeleteHall(long hallId);

    public Collection<Hall> GetAllHalls(long venueId);

    public Hall? GetHall(long hallId);
}