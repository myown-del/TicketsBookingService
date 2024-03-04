using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IHallService
{
    public void CreateHall(int venueId);

    public void DeleteHall(int hallId, int venueId);

    public List<Hall> GetAllHalls(int venueNumber);
}