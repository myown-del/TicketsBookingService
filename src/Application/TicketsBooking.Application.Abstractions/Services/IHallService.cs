using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IHallService
{
    public void CreateHall(int venueId);

    public void DeleteHall(int hallId, int venueId);

    public Collection<Hall> GetAllHalls(int venueNumber);
}