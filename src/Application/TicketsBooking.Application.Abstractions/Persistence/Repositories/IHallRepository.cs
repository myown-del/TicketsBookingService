using System.Collections.ObjectModel;
using TicketsBooking.Application.Models.Entities;

namespace TicketsBooking.Application.Abstractions.Persistence.Repositories;

public interface IHallRepository
{
    public Collection<Hall> GetAll(long venueId);

    public Hall? GetHall(long hallId);

    public void Add(Hall hall);

    public void Remove(long hallId);
}